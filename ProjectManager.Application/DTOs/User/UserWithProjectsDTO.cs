using ProjectManager.Application.DTOs.Project;

namespace ProjectManager.Application.DTOs.User;

public record class UserWithProjectsDTO
{
    public string? UserName { get; set; }
    public string? UserId { get; set; }
    public IEnumerable<ProjectDTO>? Projects { get; set; }
}
