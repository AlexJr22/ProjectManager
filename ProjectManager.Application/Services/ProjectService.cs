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

        await unitOfWork.CommitAsync();

        return mapper.Map<ProjectDTO>(newProject);
    }

    public async Task<ProjectDTO> UpdateAsync(UpdateProjectDTO projectDTO, int id)
    {
        var entity = new ProjectDTO { Id = id, ProjectName = projectDTO.ProjectName };

        unitOfWork.ProjectRepository.Update(mapper.Map<ProjectModel>(entity));

        await unitOfWork.CommitAsync();

        return mapper.Map<ProjectDTO>(entity);
    }

    public async Task<ProjectDTO> Delete(int id)
    {
        var project = await unitOfWork.ProjectRepository.GetAsync(p => p.Id == id)!;

        var projectDeleted = unitOfWork.ProjectRepository.Detele(project);

        await unitOfWork.CommitAsync();

        return mapper.Map<ProjectDTO>(projectDeleted);
    }
}
