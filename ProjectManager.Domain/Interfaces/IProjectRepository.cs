using ProjectManager.Domain.Entities;
using System.Linq.Expressions;

namespace ProjectManager.Domain.Interfaces;

public interface IProjectRepository
{
    Task<ProjectModel> GetAsync(Expression<Func<ProjectModel, bool>> expression);
    Task<IEnumerable<ProjectModel>> GetAllAsync();
    Task<ProjectModel> CreateAsync(ProjectModel entity);
    Task<ProjectModel> UpdateAsync(ProjectModel entity);
    Task<ProjectModel> DeteleAsync(ProjectModel entity);
}
