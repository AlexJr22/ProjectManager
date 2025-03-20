namespace ProjectManager.Domain.Entities;

public sealed class ProjectModel
{
    public int Id { get; private set; }
    public string? ProjectName { get; private set; }
    public DateTime CreateAt { get; private set; }
    public ICollection<TaskModel>? Tasks { get; private set; }

    // public ICollection<UserModel>? Users { get; private set; }

    private ProjectModel()
    {
        CreateAt = DateTime.UtcNow;
    }

    public ProjectModel(string projectName, ICollection<TaskModel>? tasks)
    {
        ProjectName = NameValidation(projectName);
        CreateAt = DateTime.UtcNow;
        Tasks = tasks;
    }

    public void Update(string projectName, ICollection<TaskModel>? tasks)
    {
        if (!string.IsNullOrWhiteSpace(projectName))
            ProjectName = NameValidation(projectName);

        if (tasks != null)
            Tasks = tasks;
    }

    private string NameValidation(string name)
    {
        if (name.Length < 3)
            throw new ArgumentException(
                "The project name cannot have less than three letters!",
                nameof(name)
            );

        if (name.Length > 25)
            throw new ArgumentException(
                "The project name cannot have more than twenty-five letters!",
                nameof(name)
            );

        return name;
    }
}
