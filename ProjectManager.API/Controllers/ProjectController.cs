using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.Interfaces;

namespace ProjectManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService projectService = projectService;

    [HttpGet("getAll")]
    public async Task<IEnumerable<ProjectDTO>> GetAll()
    {
        var projects = await projectService.GetAllAsync();

        return projects;
    }

    [HttpGet("getById/id/{id:int}")]
    public async Task<ActionResult<ProjectDTO>> GetById(int id)
    {
        var project = await projectService.GetAsync(p => p.Id == id);

        if (project is null)
            return NotFound();

        return project;
    }

    [HttpPost("createProject")]
    public async Task<ActionResult<ProjectDTO>> Create(CreatingProjectDTO newProject)
    {
        var project = await projectService.CreateAsync(newProject);

        if (project is null)
            return BadRequest();

        return project;
    }

    [HttpPut("update/{id:int}")]
    public async Task<ActionResult<ProjectDTO>> Update(UpdateProjectDTO projectDTO, int id)
    {
        var updatedProject = await projectService.Update(projectDTO, id);

        if (updatedProject is null)
            return BadRequest();

        return updatedProject;
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<ProjectDTO> Delete(int id)
    {
        var deletedProject = await projectService.Delete(id);

        return deletedProject;
    }
}
