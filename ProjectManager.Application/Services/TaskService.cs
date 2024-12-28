using AutoMapper;
using ProjectManager.Application.DTOs.Task;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using System.Linq.Expressions;

namespace ProjectManager.Application.Services;

public class TaskService(ITaskRepository taskRepository, Mapper mapper) : ITaskService
{
    private readonly Mapper _mapper = mapper;
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<IEnumerable<TaskDTO>> GetAllTasks()
    {
        var tasks = await _taskRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }

    public async Task<TaskDTO> GetAsync(Expression<Func<TaskModel, bool>> expression)
    {
        var task = await _taskRepository.GetAsync(expression);

        return _mapper.Map<TaskDTO>(task);
    }

    public async Task<TaskDTO> CreateTask(CreatingTaskDTO entity)
    {
        var newTask = await _taskRepository
            .CreateAsync(_mapper.Map<TaskModel>(entity));

        return _mapper.Map<TaskDTO>(newTask);
    }

    public async Task<TaskDTO> UpdateTask(UpdateTaskDTO entity)
    {
        var updatedTask = await _taskRepository
            .UpdateAsync(_mapper.Map<TaskModel>(entity));

        return _mapper.Map<TaskDTO>(updatedTask);
    }

    public async Task<TaskDTO> DeleteTask(TaskDTO entity)
    {
        var deletedTask = await _taskRepository
            .DeleteAsync(_mapper.Map<TaskModel>(entity));

        return _mapper.Map<TaskDTO>(deletedTask);
    }
}
