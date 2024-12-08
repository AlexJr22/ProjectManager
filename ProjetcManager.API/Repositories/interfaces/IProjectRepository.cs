using ProjetcManager.API.DTOs.Project;
using ProjetcManager.API.Models;

namespace ProjetcManager.API.Repositories.interfaces;

public interface IProjectRepository : IRepository<ProjectModel>
{
    Task<IEnumerable<ProjectModel>> GetAllProjectsWithTasks();
    Task<ProjectModel> GetProjectWithUsers(int id);
}
