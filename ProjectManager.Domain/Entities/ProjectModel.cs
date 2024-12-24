namespace ProjectManager.Domain.Entities;

public sealed class ProjectModel
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public ICollection<TaskModel>? Tasks { get; set; }
    public ICollection<UserModel>? Users { get; set; }
}
