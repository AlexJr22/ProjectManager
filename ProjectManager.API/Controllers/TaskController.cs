using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.DTOs.Task;
using ProjectManager.Application.Interfaces;

namespace ProjectManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController(ITaskService ItaskService) : ControllerBase
{
    private readonly ITaskService taskService = ItaskService;

    [HttpGet("getAllTask")]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTask()
    {
        var tasks = await taskService.GetAllTasks();

        return Ok(tasks);
    }

    [HttpGet("getById/id/{id:int}")]
    public async Task<ActionResult<TaskDTO>> GetById(int id)
    {
        var task = await taskService.GetAsync(t => t.Id == id);

        if (task is null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost("creatingNewTask")]
    public async Task<ActionResult<TaskDTO>> Create(CreatingTaskDTO taskDTO)
    {
        var newTask = await taskService.CreateAsync(taskDTO);

        if (newTask is null)
            return BadRequest();

        return newTask;
    }

    [HttpPatch("updatingTask/id/{id:int}")]
    public async Task<ActionResult<TaskDTO>> Update(UpdateTaskDTO task, int id)
    {
        var taskUpdated = await taskService.Update(task, id);

        if (taskUpdated is null)
            return BadRequest();

        return taskUpdated;
    }

    [HttpDelete("deleting/id/{id:int}")]
    public async Task<ActionResult<TaskDTO>> Delete(int id)
    {
        var deletedTask = await taskService.Delete(id);

        return Ok(deletedTask);
    }
}
