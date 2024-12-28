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

        return mapper.Map<ProjectDTO>(project);
    }

    public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();

        return mapper.Map<IEnumerable<ProjectDTO>>(projects); ;
    }

    public async Task<ProjectDTO> CreateAsync(CreatingProjectDTO projectDTO)
    {
        var newProject = await _projectRepository.CreateAsync(mapper.Map<ProjectModel>(projectDTO));

        return mapper.Map<ProjectDTO>(newProject);
    }

    public async Task<ProjectDTO> UpdateAsync(ProjectDTO projectDTO)
    {
        var updatedProject = await _projectRepository.UpdateAsync(mapper.Map<ProjectModel>(projectDTO));

        return mapper.Map<ProjectDTO>(updatedProject);
    }

    public async Task<ProjectDTO> DeleteAsync(ProjectDTO project)
    {
        var projectDeleted = await _projectRepository.DeteleAsync(mapper.Map<ProjectModel>(project));

        return mapper.Map<ProjectDTO>(projectDeleted); ;
    }
}
