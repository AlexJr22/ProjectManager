using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<ProjectModel>>? GetAllProjects();
    Task<IEnumerable<ProjectModel>>? GetProjectsWithTasks();
    Task<ProjectModel>? GetProjectWithUsers();
    Task<ProjectModel>? GetProjectById();
    Task<ProjectModel>? CreateProject(ProjectModel project);
    Task<ProjectModel>? UpdateProject(int id, ProjectModel project);
    Task<ProjectModel>? DeleteProject(int id);
}
