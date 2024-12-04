using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetcManager.API.Models;

namespace ProjetcManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UserManager<UserModel> userManager) : ControllerBase
{
    private readonly UserManager<UserModel> _userManager = userManager;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers(string name)
    {
        var users = await _userManager.Users.ToListAsync();

        return Ok(users);
    }
}
