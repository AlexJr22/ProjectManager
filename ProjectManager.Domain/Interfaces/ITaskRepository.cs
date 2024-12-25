using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskModel>>? GetAllTaskAsync();
    Task<IEnumerable<TaskModel>>? GetTaskWithUsersAsync();
    Task<TaskModel>? GetTaskByIdAsync();
    Task<TaskModel>? CreateTaskAsync(TaskModel task);
    Task<TaskModel>? UpdateTaskAsync(int id, TaskModel task);
    Task<TaskModel>? DeleteTaskAsync(int id);
}