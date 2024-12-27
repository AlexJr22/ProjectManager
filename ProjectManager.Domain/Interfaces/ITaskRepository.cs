using ProjectManager.Domain.Entities;
using System.Linq.Expressions;

namespace ProjectManager.Domain.Interfaces;

public interface ITaskRepository
{
    Task<TaskModel> GetAsync(Expression<Func<TaskModel, bool>> expression);
    Task<IEnumerable<TaskModel>> GetAllAsync();
    Task<TaskModel> CreateAsync(TaskModel entity);
    Task<TaskModel> UpdateAsync(TaskModel entity);
    Task<TaskModel> DeleteAsync(TaskModel entity);
}