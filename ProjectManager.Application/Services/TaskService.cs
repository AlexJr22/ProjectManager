using System.Linq.Expressions;
using ProjectManager.Application.DTOs.Task;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Mappings;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Services;

public class TaskService(IUnitOfWork iunitOfWork) : ITaskService
{
    private readonly IUnitOfWork unitOfWork = iunitOfWork;

    public async Task<IEnumerable<TaskDTO>> GetAllTasks()
    {
        var tasks = await unitOfWork.TaskRepository.GetAllAsync();

        return Mapper.Map<TaskDTO, TaskModel>(tasks);
    }

    public async Task<TaskDTO> GetAsync(Expression<Func<TaskModel, bool>> expression)
    {
        var task = await unitOfWork.TaskRepository.GetAsync(expression);

        return Mapper.Map<TaskDTO, TaskModel>(task!);
    }

    public async Task<TaskDTO> CreateAsync(CreatingTaskDTO entity)
    {
        var newTask = await unitOfWork
            .TaskRepository
            .CreateAsync(Mapper.Map<TaskModel, CreatingTaskDTO>(entity));

        await unitOfWork.CommitAsync();

        return Mapper.Map<TaskDTO, TaskModel>(newTask);
    }

    public async Task<TaskDTO> Update(UpdateTaskDTO entity, int id)
    {
        var task = new TaskDTO
        {
            Id = id,
            ProjectId = entity.ProjectId,
            TaskDescription = entity.TaskDescription,
            TaskName = entity.TaskName,
            TaskStatus = entity.TaskStatus
        };

        var updatedTask = unitOfWork.TaskRepository.Update(Mapper.Map<TaskModel, TaskDTO>(task));

        await unitOfWork.CommitAsync();

        return Mapper.Map<TaskDTO, TaskModel>(updatedTask);
    }

    public async Task<TaskDTO> Delete(int id)
    {
        var entity = await unitOfWork.TaskRepository.GetAsync(t => t.Id == id);

        if (entity is not null)
        {
            _ = unitOfWork.TaskRepository.Delete(entity);

            await unitOfWork.CommitAsync();

            return Mapper.Map<TaskDTO, TaskModel>(entity);
        }

        return new();
    }
}
