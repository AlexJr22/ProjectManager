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

    [HttpGet]
    public async Task<IEnumerable<ProjectDTO>> GetAll()
    {
        var projects = await projectService.GetAllAsync();

        return mapper.Map<IEnumerable<ProjectDTO>>(projects);
    }
}
