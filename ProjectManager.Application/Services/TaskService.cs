using System.Linq.Expressions;
using AutoMapper;
using ProjectManager.Application.DTOs.Task;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Services;

public class TaskService(IUnitOfWork iunitOfWork, IMapper mapper) : ITaskService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork unitOfWork = iunitOfWork;

    public async Task<IEnumerable<TaskDTO>> GetAllTasks()
    {
        var tasks = await unitOfWork.TaskRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }

    public async Task<TaskDTO> GetAsync(Expression<Func<TaskModel, bool>> expression)
    {
        var task = await unitOfWork.TaskRepository.GetAsync(expression);

        return _mapper.Map<TaskDTO>(task);
    }

    public async Task<TaskDTO> CreateAsync(CreatingTaskDTO entity)
    {
        var newTask = await unitOfWork.TaskRepository.CreateAsync(_mapper.Map<TaskModel>(entity));

        await unitOfWork.CommitAsync();

        return _mapper.Map<TaskDTO>(newTask);
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

        _ = unitOfWork.TaskRepository.Update(_mapper.Map<TaskModel>(task));

        await unitOfWork.CommitAsync();

        return _mapper.Map<TaskDTO>(task);
    }

    public async Task<TaskDTO> Delete(int id)
    {
        var entity = await unitOfWork.TaskRepository.GetAsync(t => t.Id == id);

        _ = unitOfWork.TaskRepository.Delete(entity!);

        await unitOfWork.CommitAsync();

        return _mapper.Map<TaskDTO>(entity);
    }
}
