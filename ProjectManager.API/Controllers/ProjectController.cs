using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.Interfaces;

namespace ProjectManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService; 

    [HttpGet]
    public async Task<IEnumerable<ProjectDTO>> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        return projects;
    }
}
