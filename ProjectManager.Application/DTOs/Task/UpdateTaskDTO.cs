namespace ProjectManager.Application.DTOs.Task;

public record class UpdateTaskDTO
{
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public bool TaskStatus { get; set; } = false;
    public int? ProjectId { get; set; }
}
