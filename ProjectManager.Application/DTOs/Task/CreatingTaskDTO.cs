namespace ProjectManager.Application.DTOs.Task;

public record class CreatingTaskDTO
{
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public bool TaskStatus { get; set; }
    public int? ProjectId { get; set; }
}
