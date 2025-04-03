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

    public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
    {
        var projects = await unitOfWork.ProjectRepository.GetAllAsync();

        return mapper.Map<IEnumerable<ProjectDTO>>(projects);
    }

    public async Task<ProjectDTO> GetAsync(Expression<Func<ProjectModel, bool>> expression)
    {
        var project = await unitOfWork.ProjectRepository.GetAsync(expression)!;

        return mapper.Map<ProjectDTO>(project);
    }

    public async Task<ProjectWithTasksDTO?> GetProjectWithTasksAsync(int id)
    {
        var project = await unitOfWork.ProjectRepository.GetProjectWithTasksAsync(id);

        return mapper.Map<ProjectWithTasksDTO?>(project);
    }

    public async Task<ProjectDTO> CreateAsync(CreatingProjectDTO projectDTO)
    {
        var newProject = await unitOfWork
            .ProjectRepository
            .CreateAsync(mapper.Map<ProjectModel>(projectDTO));

        await unitOfWork.CommitAsync();

        return mapper.Map<ProjectDTO>(newProject);
    }

    public async Task<ProjectDTO> Update(UpdateProjectDTO entity, int id)
    {
        var projectDto = new ProjectDTO { Id = id, ProjectName = entity.ProjectName };

        _ = unitOfWork.ProjectRepository.Update(mapper.Map<ProjectModel>(projectDto));

        await unitOfWork.CommitAsync();

        return mapper.Map<ProjectDTO>(projectDto);
    }

    public async Task<ProjectDTO> Delete(int id)
    {
        var entity = await unitOfWork.ProjectRepository.GetAsync(p => p.Id == id)!;

        _ = unitOfWork.ProjectRepository.Delete(entity!);

        await unitOfWork.CommitAsync();

        return mapper.Map<ProjectDTO>(entity);
    }
}
 