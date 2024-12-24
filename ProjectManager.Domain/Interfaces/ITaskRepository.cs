using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskModel>>? GetAllTask();
    Task<IEnumerable<TaskModel>>? GetTaskWithUsers();
    Task<TaskModel>? GetTaskById();
    Task<TaskModel>? CreateTask(TaskModel task);
    Task<TaskModel>? UpdateTask(int id, TaskModel task);
    Task<TaskModel>? DeleteTask(int id);
}