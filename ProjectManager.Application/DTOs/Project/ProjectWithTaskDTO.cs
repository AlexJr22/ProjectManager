using ProjectManager.Application.DTOs.Task;

namespace ProjectManager.Application.DTOs.Project;

public record class ProjectWithTasksDTO
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public string CreateAt { get; set; } = null!;
    public IEnumerable<TaskDTO>? Tasks { get; set; }
}
