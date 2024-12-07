using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetcManager.API.DTOs.Mapping;
using ProjetcManager.API.DTOs.User;
using ProjetcManager.API.Models;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UserManager<UserModel> userManager, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly UserManager<UserModel> _userManager = userManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
    {
        var users = await _userManager.Users.ToListAsync();

        return Ok(users.ToListUserDTO());
    }

    [HttpGet("GetUserByName")]
    public async Task<ActionResult<UserDTO>> GetUserByName(string name)
    {
        var user = await _userManager.Users.Include(u => u.Projects).FirstOrDefaultAsync();

        if (user is not null)
            return Ok(user.ToUserWithProjectDTO());

        return NotFound("User Not Found!");
    }

    [HttpGet("GetUserWithProjects")]
    public async Task<ActionResult<UserWithProjectDTO>> GetUserWithProjects(string name)
    {
        var user = await _userManager.Users
                                    .AsNoTracking()
                                    .Include(users => users.Projects)
                                    .FirstOrDefaultAsync();

        if (user is not null)
        {
            return Ok(user.ToUserWithProjectDTO());
        }

        return NotFound("User Not Found!");
    }

    [HttpPost("AddUserToProject")]
    public async Task<ActionResult<UserWithProjectDTO>> AddUserToProject(string userGuid, int projectId)
    {
        var user = await _userManager.Users.Include(user => user.Projects).FirstOrDefaultAsync();
        var project = await _unitOfWork.ProjectRepository.GetAsync(p => p.Id == projectId);

        if (user is not null && project is not null)
        {
            user.Projects!.Add(project!);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok(user.ToUserWithProjectDTO());
        }

        return BadRequest("Could't add user to project!");
    }
}
