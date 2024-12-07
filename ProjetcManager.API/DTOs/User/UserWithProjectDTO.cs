using ProjetcManager.API.DTOs.Project;

namespace ProjetcManager.API.DTOs.User;

public record class UserWithProjectDTO
{
    public string? UserName { get; set; }
    public string? UserId { get; set; }
    public IEnumerable<ProjectDTO>? Projects { get; set; }
}
