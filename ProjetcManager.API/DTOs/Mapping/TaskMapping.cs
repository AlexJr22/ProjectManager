using ProjetcManager.API.Models;

namespace ProjetcManager.API.DTOs.Mapping;

public static class TaskMapping
{
    public static TaskModel ToTaskModel(this TaskDTO taskDTO)
    {
        ArgumentNullException.ThrowIfNull(taskDTO);

        return new TaskModel()
        {
            Id = taskDTO.Id,
            TaskName = taskDTO.TaskName,
            TaskDescription = taskDTO.TaskDescription,
            TaskStatus = taskDTO.TaskStatus,
            ProjectId = taskDTO.ProjectId,
        };
    }
    
    public static TaskModel ToTaskModel(this CreatingTaskDTO taskDTO)
    {
        ArgumentNullException.ThrowIfNull(taskDTO);

        return new TaskModel()
        {
            TaskName = taskDTO.TaskName,
            TaskDescription = taskDTO.TaskDescription,
            TaskStatus = taskDTO.TaskStatus,
            ProjectId = taskDTO.ProjectId,
        };
    }

    public static TaskDTO ToTaskDTO(this TaskModel taskModel)
    {
        ArgumentNullException.ThrowIfNull(taskModel);

        return new TaskDTO()
        {
            Id = taskModel.Id,
            TaskName = taskModel.TaskName,
            TaskDescription = taskModel.TaskDescription,
            TaskStatus = taskModel.TaskStatus,
            ProjectId = taskModel.ProjectId,
        };
    }

    public static IEnumerable<TaskDTO> ToListTaskDTO(this IEnumerable<TaskModel> tasks)
    {
        ArgumentNullException.ThrowIfNull(tasks);

        return tasks.Select(t => new TaskDTO
        {
            Id = t.Id,
            TaskName = t.TaskName,
            TaskDescription = t.TaskDescription,
            TaskStatus = t.TaskStatus,
            ProjectId = t.ProjectId,
        });
    }

    public static IEnumerable<TaskModel> ToListTaskModel(this IEnumerable<TaskDTO> tasks)
    {
        ArgumentNullException.ThrowIfNull(tasks);

        return tasks.Select(t => new TaskModel
        {
            Id = t.Id,
            TaskName = t.TaskName,
            TaskDescription = t.TaskDescription,
            TaskStatus = t.TaskStatus,
            ProjectId = t.ProjectId,
        });
    }
}
