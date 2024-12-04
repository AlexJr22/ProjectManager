using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetcManager.API.DTOs;
using ProjetcManager.API.Models;
using ProjetcManager.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetcManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    ITokenService tokenService, 
    UserManager<UserModel> userManager,
    RoleManager<IdentityRole> roleManager, 
    IConfiguration configuration,
    ILogger<AuthController> logger) : ControllerBase
{
    private readonly ITokenService tokenService = tokenService;
    private readonly UserManager<UserModel> userManager = userManager;
    private readonly RoleManager<IdentityRole> roleManager = roleManager;
    private readonly IConfiguration configuration = configuration;
    private readonly ILogger<AuthController> logger = logger;

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] LoginModelDTO loginModel)
    {
        var user = await userManager.FindByNameAsync(loginModel.UserName!);

        if (user is not null && await userManager.CheckPasswordAsync(user, loginModel.Password!))
        {
            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName!),
                new(ClaimTypes.Email, user.Email!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("id", user.UserName!)
            };

            foreach (var userRole in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var token = tokenService.GenerateAcessToken(authClaims, configuration);

            var refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInMinutes"],
                out int refreshTokenValidityInMinutes);

            user.RefreshToken = refreshToken;

            user.RefreshTokenExpiryTime = DateTime.Now
                .AddMinutes(refreshTokenValidityInMinutes);

            await userManager.UpdateAsync(user);

            return Ok(
                new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                }
            );
        }

        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModelDTO model)
    {
        var userExists = await userManager.FindByNameAsync(model.UserName!);

        if (userExists is not null)
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new ResponceDTO { Status = "Erro", Erro = "user already exists!" }
            );


        UserModel user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.UserName,
        };

        var result = await userManager.CreateAsync(user, model.Password!);

        if (!result.Succeeded)
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new ResponceDTO { Erro = "User creation Failed!", Status = "500" }
            );

        return Ok(new ResponceDTO { Status = "Seccess", Erro = "User created successfully!" });
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenModelDTO tokenModel)
    {
        if (tokenModel is null)
            return BadRequest("Invalid client request");

        string? accessToken = tokenModel.AccessToken
            ?? throw new ArgumentNullException(nameof(tokenModel));

        string? refreshToken = tokenModel.RefreshToken
            ?? throw new ArgumentNullException(nameof(tokenModel));

        var principal = tokenService.GetPrincipalFromExpiredToKen(accessToken!, configuration);

        if (principal is null)
            return BadRequest("Invalid access token/refresh token");

        var username = principal.Identity!.Name;

        var user = await userManager.FindByNameAsync(username!);

        if (user is null || user.RefreshToken != refreshToken
                         || user.RefreshTokenExpiryTime <= DateTime.Now)
            return BadRequest("Invalid access token/refresh token");

        var newAccessToken = tokenService.GenerateAcessToken(
            principal.Claims.ToList(),
            configuration
        );

        var newRefreshToken = tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await userManager.UpdateAsync(user);

        return new ObjectResult(
            new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            }
        );
    }

    [Authorize]
    [HttpPost]
    [Route("revoke/{username}")]
    public async Task<IActionResult> Revoke(string username)
    {
        var user = await userManager.FindByNameAsync(username);

        if (user is null)
            return BadRequest("Invalid user name");

        user.RefreshToken = null;

        await userManager.UpdateAsync(user);

        return NoContent();
    }

    [HttpPost]
    [Route("CreateRole")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);

        if (!roleExist)
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));

            if (roleResult.Succeeded)
            {
                logger.LogInformation(1, "Roles Added");
                return StatusCode(
                    StatusCodes.Status201Created,
                    new ResponceDTO
                    {
                        Status = "Success",
                        Erro = "Success to create role"
                    }
                );
            }

            logger.LogInformation(2, "Error");
            return StatusCode(
                StatusCodes.Status400BadRequest,
                new ResponceDTO
                {
                    Status = "Error",
                    Erro = $"Issue adding the new {roleName} role"
                }
            );
        }

        return StatusCode(
            StatusCodes.Status400BadRequest,
            new ResponceDTO
            {
                Status = "Error",
                Erro = "Role already exist."
            }
        );
    }

    [HttpPost]
    [Route("AddToRoleAsync")]
    public async Task<IActionResult> AddUserToRole(string email, string roleName)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user is not null)
        {
            var result = await userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                var mensage = $"User {user.Email} added to the {roleName} role";
                logger.LogInformation(1, mensage);

                return StatusCode(
                    StatusCodes.Status200OK,
                    new ResponceDTO
                    {
                        Erro = mensage,
                        Status = "Success"
                    }
                );
            }

            var erroMensage = $"Error: unable to add user {user.Email} to the {roleManager} role";
            logger.LogInformation(1, erroMensage);

            return StatusCode(
                StatusCodes.Status400BadRequest,
                new ResponceDTO
                {
                    Status = "Error",
                    Erro = erroMensage
                }
            );
        }

        return BadRequest(new { error = "Unable to find user" });
    }
}
