using ProjetcManager.API.DTOs.Task;

namespace ProjetcManager.API.DTOs.Project;

public record class ProjectWithTasksDTO
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public IEnumerable<TaskDTO>? Tasks { get; set; }
}
