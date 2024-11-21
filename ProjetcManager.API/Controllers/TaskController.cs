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

    [HttpGet("GetTaskById/Id/{id:int}", Name = "GetById")]
    public async Task<ActionResult<TaskDTO>> GetTaskById(int id)
    {
        var taskModel = await _unitOfWork
            .TaskRepository.GetAsync(task => task.Id == id);

        if (taskModel is not null)
        {
            var taskDTO = taskModel.ToTaskDTO();
            return Ok(taskDTO);
        }

        return NotFound();
    }

    [HttpGet("GetTaskByName/src/{taskName}")]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTaskByName(string taskName)
    {

        IEnumerable<TaskModel>? tasks = await _unitOfWork.TaskRepository.GetByNameAsync(
            tasks => tasks.TaskName!.Contains(taskName));

        if (tasks is not null)
            return Ok(tasks.ToListTaskDTO());

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

        newTaskDTO = taskModel.ToTaskDTO();

        return CreatedAtRoute(
            "GetById",
            new { id = newTaskDTO.Id },
            newTaskDTO
        );
    }

    [HttpPut("UpdateTask/Id/{id:int}")]
    public async Task<ActionResult> UpdateTaskById(int id, TaskDTO updatedTask)
    {
        if (updatedTask is null)
            return BadRequest($"Could't to update the task of Id='{id}'");

        var UpdatedTask = updatedTask.ToTaskModel();

        _unitOfWork.TaskRepository.Update(UpdatedTask);
        await _unitOfWork.CommitAsync();

        return Created();
    }

    [HttpDelete("DeleteTask/id/{id:int}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        var taskModel = await _unitOfWork.TaskRepository
            .GetAsync(task => task.Id == id);

        if (taskModel is null)
            return Ok("Task Deleted!");

        _unitOfWork.TaskRepository.Delete(taskModel);
        await _unitOfWork.CommitAsync();

        return Ok($"Task of id={taskModel.Id} was deleted with success!");
    }
}
