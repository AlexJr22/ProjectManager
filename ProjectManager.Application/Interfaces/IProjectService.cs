using System.Linq.Expressions;
using ProjectManager.Application.DTOs.Project;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDTO>> GetAllAsync();
    Task<ProjectDTO> GetAsync(Expression<Func<ProjectModel, bool>> expression);

    Task<ProjectWithTasksDTO?> GetProjectWithTasksAsync(int id);
    Task<ProjectDTO> CreateAsync(CreatingProjectDTO entity);
    Task<ProjectDTO> Update(UpdateProjectDTO entity, int id);
    Task<ProjectDTO> Delete(int id);
}
