using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<ProjectModel>>? GetAllProjectsAsync();
    Task<IEnumerable<ProjectModel>>? GetProjectsWithTasksAsync();
    Task<ProjectModel>? GetProjectWithUsersAsync();
    Task<ProjectModel>? GetProjectByIdAsync();
    Task<ProjectModel>? CreateProjectAsync(ProjectModel project);
    Task<ProjectModel>? UpdateProjectAsync(int id, ProjectModel project);
    Task<ProjectModel>? DeleteProjectAsync(int id);
}
