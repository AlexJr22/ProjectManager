using System.Linq.Expressions;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Application.Interfaces;
using ProjectManager.Application.Mappings;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Services;

public class ProjectService(IUnitOfWork unitOfWord) : IProjectService
{
    private readonly IUnitOfWork unitOfWork = unitOfWord;

    public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
    {
        var projects = await unitOfWork.ProjectRepository.GetAllAsync();

        return Mapper.Map<ProjectDTO, ProjectModel>(projects);
    }

    public async Task<ProjectDTO?> GetAsync(Expression<Func<ProjectModel, bool>> expression)
    {
        var project = await unitOfWork.ProjectRepository.GetAsync(expression)!;

        if (project is not null)
            return Mapper.Map<ProjectDTO, ProjectModel>(project!);

        return null;
    }

    public async Task<ProjectWithTasksDTO?> GetProjectWithTasksAsync(int id)
    {
        var project = await unitOfWork.ProjectRepository.GetProjectWithTasksAsync(id);

        if (project is not null)
            return Mapper.Map<ProjectWithTasksDTO, ProjectModel>(project!);

        return null;
    }

    public async Task<ProjectDTO> CreateAsync(CreatingProjectDTO projectDTO)
    {
        var newProject = await unitOfWork
            .ProjectRepository
            .CreateAsync(Mapper.Map<ProjectModel, CreatingProjectDTO>(projectDTO));

        await unitOfWork.CommitAsync();

        return Mapper.Map<ProjectDTO, ProjectModel>(newProject);
    }

    public async Task<ProjectDTO> Update(UpdateProjectDTO entity, int id)
    {
        var project = new ProjectModel(entity.ProjectName!, id);

        var updatedProject = unitOfWork.ProjectRepository.Update(project);

        await unitOfWork.CommitAsync();

        return Mapper.Map<ProjectDTO, ProjectModel>(updatedProject);
    }

    public async Task<ProjectDTO> Delete(int id)
    {
        var entity = await unitOfWork.ProjectRepository.GetAsync(p => p.Id == id);

        if (entity is not null)
        {
            _ = unitOfWork.ProjectRepository.Delete(entity!);

            await unitOfWork.CommitAsync();

            return Mapper.Map<ProjectDTO, ProjectModel>(entity!);
        }

        return new();
    }
}
