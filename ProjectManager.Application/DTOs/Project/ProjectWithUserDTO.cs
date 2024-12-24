using ProjectManager.Application.DTOs.User;

namespace ProjectManager.Application.DTOs.Project;

public record class ProjectWithUserDTO
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public IEnumerable<UserDTO>? Users { get; set; }
}
