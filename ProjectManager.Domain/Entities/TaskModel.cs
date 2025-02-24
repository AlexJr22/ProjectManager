using System.Text.RegularExpressions;

namespace ProjectManager.Domain.Entities;

public sealed class TaskModel
{
    public int Id { get; private set; }
    public string TaskName { get; private set; }
    public string? TaskDescription { get; private set; }
    public bool TaskStatus { get; private set; }
    public int? ProjectId { get; private set; }
    public ProjectModel? Project { get; private set; }

    public TaskModel(string taskName, string? taskDescription, int? projectId, int id)
    {
        TaskName = NameValidation(taskName);
        TaskDescription = taskDescription;
        TaskStatus = false;
        ProjectId = projectId;
        Id = id;
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

    public void Update(string taskName, string? taskDescription, int? projectId, bool taskStatus)
    {
        TaskName = taskName;
        TaskDescription = taskDescription;
        ProjectId = projectId;
        TaskStatus = taskStatus;
    }
}
