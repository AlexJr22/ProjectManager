namespace ProjectManager.Application.DTOs.Task;

public record class TaskDTO
{
    public int Id { get; set; }
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public bool TaskStatus { get; set; }
    public int? ProjectId { get; set; }
}
