using Microsoft.AspNetCore.Mvc;
using ProjetcManager.API.DTOs;
using ProjetcManager.API.DTOs.Mapping;
using ProjetcManager.API.Models;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController(IUnitOfWork unitOfWork)
    : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [HttpGet("GetAll", Name = "GetAll")]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTasks()
    {
        var tasks = await _unitOfWork.TaskRepository.GetAllTask();
        return Ok(tasks);
    }

    [HttpGet("GetTaskById")]
    public async Task<ActionResult<TaskDTO>> GetTaskById(int id)
    {
        var taskModel = await _unitOfWork.TaskRepository.GetAsync(task => task.Id == id);

        if (taskModel is not null)
        {
            var taskDTO = taskModel.ToTaskDTO();
            return Ok(taskDTO);
        }

        return NotFound();
    }

    [HttpGet("GetTaskByName")]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTaskByName(string? taskName)
    {
        TaskModel? task = await _unitOfWork.TaskRepository.GetAsync(task => task.TaskName == taskName);

        if (task is not null)
            return Ok(task.ToTaskDTO());

        return NotFound($"Could't find the task '{taskName}'");
    }

    [HttpPost("Creating")]
    public async Task<ActionResult<TaskDTO>> CreatingANewTask(TaskDTO newTaskDTO)
    {
        if (newTaskDTO is null)
            return BadRequest("Invalid Request");

        var taskModel = newTaskDTO.ToTaskModel();

        _unitOfWork.TaskRepository.Create(taskModel);
        await _unitOfWork.CommitAsync();

        return Ok(newTaskDTO);
    }

}
