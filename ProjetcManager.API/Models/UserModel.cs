using Microsoft.AspNetCore.Identity;

namespace ProjetcManager.API.Models;

public class UserModel : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public ICollection<ProjectModel>? Projects { get; set; }
}