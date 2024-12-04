using ProjetcManager.API.Models;

namespace ProjetcManager.API.Repositories.interfaces;

public interface ITaskRepository : IRepository<TaskModel>
{
    Task<IEnumerable<TaskModel>> GetTaskWithProjects();
}
