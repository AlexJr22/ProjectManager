using ProjectManager.Application.DTOs.Task;

namespace ProjectManager.Application.DTOs.Project;

public record class ProjectWithTasksDTO
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public DateTime CreateAt { get; set; }
    public ICollection<TaskDTO>? Tasks { get; set; }
}
