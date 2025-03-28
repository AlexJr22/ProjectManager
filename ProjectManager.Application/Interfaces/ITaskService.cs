using System.Linq.Expressions;
using ProjectManager.Domain.Entities;
using ProjectManager.Application.DTOs.Task;

namespace ProjectManager.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDTO>> GetAllTasks();
    Task<TaskDTO> GetAsync(Expression<Func<TaskModel, bool>> expression);
    Task<TaskDTO> CreateAsync(CreatingTaskDTO entity);
    Task<TaskDTO> Update (UpdateTaskDTO entity, int id);
    Task<TaskDTO> Delete(int id);
}
