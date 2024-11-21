namespace ProjetcManager.API.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public ICollection<TaskModel>? Tasks { get; set; }
}
