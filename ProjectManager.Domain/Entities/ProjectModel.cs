namespace ProjectManager.Domain.Entities;

public sealed class ProjectModel
{
    public int Id { get; set; }
    public string? ProjectName { get; private set; }
    public ICollection<TaskModel>? Tasks { get; private set; }
    public ICollection<UserModel>? Users { get; private set; }
}
