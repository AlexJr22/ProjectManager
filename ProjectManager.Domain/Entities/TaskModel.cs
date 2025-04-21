namespace ProjectManager.Domain.Entities;

public sealed class TaskModel
{
    public int Id { get; private set; }
    public string? TaskName { get; private set; }
    public string? TaskDescription { get; private set; }
    public bool TaskStatus { get; private set; }
    public int? ProjectId { get; private set; }
    public DateTime CreateAt { get; private set; }
    public ProjectModel? Project { get; private set; }

    public TaskModel()
    {
        CreateAt = DateTime.UtcNow;
    }

    public TaskModel(
        string taskName,
        string? taskDescription,
        int? projectId,
        int id,
        ProjectModel? project
    )
    {
        TaskName = NameValidation(taskName);
        TaskDescription = taskDescription;
        TaskStatus = false;
        ProjectId = projectId;
        Id = id;
        Project = project;
        CreateAt = DateTime.UtcNow;
    }

    public void Update(string taskName, string? taskDescription, int? projectId, bool taskStatus)
    {
        if (taskName is not null)
            TaskName = taskName;

        if (projectId is not null)
            ProjectId = projectId;

        TaskStatus = taskStatus;
        TaskDescription = taskDescription;
    }

    private string NameValidation(string name)
    {
        if (name.Length < 3)
            throw new ArgumentException(
                "The name cannot have less than three letters!",
                nameof(name)
            );

        if (name.Length > 25)
            throw new ArgumentException(
                "The name cannot have more than twenty-five letters!",
                nameof(name)
            );

        return name;
    }
}
