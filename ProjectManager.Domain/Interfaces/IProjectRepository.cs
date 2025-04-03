using System.Linq.Expressions;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Interfaces;

public interface IProjectRepository : IRepository<ProjectModel> {

    Task<ProjectModel?> GetProjectWithTasksAsync(int id);
}