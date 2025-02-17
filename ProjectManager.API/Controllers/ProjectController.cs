using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.Interfaces;

namespace ProjectManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService, IMapper mapper) : ControllerBase
{
    private readonly IProjectService projectService = projectService;
    private readonly IMapper mapper = mapper;

    [HttpGet("getAll")]
    public async Task<IEnumerable<ProjectDTO>> GetAll()
    {
        var projects = await projectService.GetAllAsync();

        return mapper.Map<IEnumerable<ProjectDTO>>(projects);
    }

    [HttpGet("getById/id/{id:int}")]
    public async Task<ProjectDTO> GetById(int id)
    {
        var project = await projectService.GetAsync(p => p.Id == id);

        return mapper.Map<ProjectDTO>(project);
    }

    [HttpPost("createProject")]
    public async Task<ProjectDTO> Create(CreatingProjectDTO newProject)
    {
        var project = await projectService.CreateAsync(newProject);

        return mapper.Map<ProjectDTO>(project);
    }

    [HttpPut("update/{id:int}")]
    public async Task<ProjectDTO> Update(UpdateProjectDTO projectDTO, int id)
    {
        var updatedProject = await projectService.Update(projectDTO, id);

        return mapper.Map<ProjectDTO>(updatedProject);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<ProjectDTO> Delete(int id)
    { 
        var deletedProject = await projectService.Delete(id);

        return deletedProject;
    }
}
