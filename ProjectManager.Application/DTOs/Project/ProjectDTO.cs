namespace ProjectManager.Application.DTOs.Project;

public record class ProjectDTO
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
}
