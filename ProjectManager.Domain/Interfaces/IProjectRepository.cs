using System.Linq.Expressions;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces;

public interface IProjectRepository
{
    Task<ProjectModel>? GetAsync(Expression<Func<ProjectModel, bool>> expression);
    Task<IEnumerable<ProjectModel>> GetAllAsync();
    Task<ProjectModel> CreateAsync(ProjectModel entity);
    ProjectModel Update(ProjectModel entity);
    ProjectModel Detele(ProjectModel entity);
}
