namespace ProjectManager.Domain.Entities;

public sealed class TaskModel
{
    public int Id { get; private set; }
    public string? TaskName { get; private set; }
    public string? TaskDescription { get; private set; }
    public bool TaskStatus { get; private set; }
    public int? ProjectId { get; private set; }
    public ProjectModel? Project { get; private set; }
}
