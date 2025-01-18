using System.Linq.Expressions;
using AutoMapper;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Services;

public class ProjectService(IUnitOfWork unitOfWord, IMapper mapper) : IProjectService
{
    private readonly IMapper mapper = mapper;
    private readonly IUnitOfWork unitOfWork = unitOfWord;

    public async Task<ProjectDTO> GetAsync(Expression<Func<ProjectModel, bool>> expression)
    {
        var project = await unitOfWork.ProjectRepository.GetAsync(expression)!;

        return mapper.Map<ProjectDTO>(project);
    }

    public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
    {
        var projects = await unitOfWork.ProjectRepository.GetAllAsync();

        return mapper.Map<IEnumerable<ProjectDTO>>(projects);
    }

    public async Task<ProjectDTO> CreateAsync(CreatingProjectDTO projectDTO)
    {
        var newProject = await unitOfWork
            .ProjectRepository
            .CreateAsync(mapper.Map<ProjectModel>(projectDTO));

        return mapper.Map<ProjectDTO>(newProject);
    }

    public ProjectDTO Update(ProjectDTO projectDTO)
    {
        var updatedProject = unitOfWork
            .ProjectRepository
            .Update(mapper.Map<ProjectModel>(projectDTO));

        return mapper.Map<ProjectDTO>(updatedProject);
    }

    public ProjectDTO Delete(ProjectDTO project)
    {
        var projectDeleted = unitOfWork
            .ProjectRepository
            .Detele(mapper.Map<ProjectModel>(project));

        return mapper.Map<ProjectDTO>(projectDeleted);
    }
}
