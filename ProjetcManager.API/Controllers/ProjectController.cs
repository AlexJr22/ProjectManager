using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetcManager.API.DTOs;
using ProjetcManager.API.DTOs.Mapping;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProjectController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [HttpGet("GetAllProjects")]
    public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
    {
        var projects = await _unitOfWork.ProjectRepository.GetAll();

        if (projects is not null)
            return Ok(projects.ToListProjectDTO());

        return BadRequest("Error to process the request!");
    }

    [HttpGet("GetByID")]
    public async Task<ActionResult<ProjectDTO>> GetProjectById(int id)
    {
        var project = await _unitOfWork.ProjectRepository
            .GetAsync(project => project.Id == id);

        if (project is not null)
            return Ok(project.ToProjectDTO());

        return BadRequest();
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ProjectDTO>> CreatingProject(ProjectDTOCreating projectDTO)
    {
        if (projectDTO is null)
            return BadRequest();

        var projectModel = projectDTO.ToProjectModel();

        _unitOfWork.ProjectRepository.Create(projectModel);
        await _unitOfWork.CommitAsync();

        return Ok(projectModel.ToProjectDTO());
    }

    [HttpPut("UpdateProject/Id/{id:int}")]
    public async Task<ActionResult<ProjectDTO>> UpdatingProject(int id, ProjectDTO projectDTO)
    {
        var project = await _unitOfWork.ProjectRepository
            .GetAsync(project => project.Id == id);

        if (project is null)
            return NotFound();

        _unitOfWork.ProjectRepository.Update(project);
        await _unitOfWork.CommitAsync();

        return Ok(project.ToProjectDTO());
    }
}
