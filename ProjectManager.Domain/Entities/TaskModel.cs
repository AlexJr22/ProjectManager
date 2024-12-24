namespace ProjectManager.Domain.Entities;

public sealed class TaskModel
{
    public int Id { get; set; }
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public bool TaskStatus { get; set; }
    public int? ProjectId { get; set; }
    public ProjectModel? Project { get; set; }
}
