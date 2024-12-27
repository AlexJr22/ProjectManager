using System.Linq.Expressions;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using AutoMapper;

namespace ProjectManager.Application.Services;

public class ProjectService(
    IProjectRepository projectRepository,
    Mapper mapper
) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly Mapper mapper = mapper;

    public async Task<ProjectDTO> GetAsync(Expression<Func<ProjectModel, bool>> expression)
    {
        var project = await _projectRepository.GetAsync(expression);
        var projectDTO = mapper.Map<ProjectDTO>(project);

        return projectDTO;
    }

    public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        var projectDTOs = mapper.Map<IEnumerable<ProjectDTO>>(projects);

        return projectDTOs;
    }

    public async Task<ProjectDTO> CreateAsync(CreatingProjectDTO projectDTO)
    {
        var entity = mapper.Map<ProjectModel>(projectDTO);
        var newProject = await _projectRepository.CreateAsync(entity);

        var newProjectDto = mapper.Map<ProjectDTO>(newProject);

        return newProjectDto;
    }

    public async Task<ProjectDTO> UpdateAsync(ProjectDTO projectDTO)
    {
        var entity = mapper.Map<ProjectModel>(projectDTO);
        var updatedProject = await _projectRepository.UpdateAsync(entity);

        var newProjectDto = mapper.Map<ProjectDTO>(updatedProject);

        return newProjectDto;
    }

    public async Task<ProjectDTO> DeleteAsync(ProjectDTO project)
    {
        var projectModel = mapper.Map<ProjectModel>(project);
        var projectDeleted = await _projectRepository.DeteleAsync(projectModel);

        var projectDto = mapper.Map<ProjectDTO>(projectDeleted);

        return projectDto;
    }
}
