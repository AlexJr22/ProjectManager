using ProjetcManager.API.DTOs.User;

namespace ProjetcManager.API.DTOs.Project;

public record class ProjectWithUsersDTO
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public IEnumerable<UserDTO>? Users { get; set; }
}
