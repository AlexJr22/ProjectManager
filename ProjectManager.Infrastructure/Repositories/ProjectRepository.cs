using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class ProjectRepository(AppDbContext DbContext) : IProjectRepository
{
    private readonly AppDbContext context = DbContext;

    public async Task<IEnumerable<ProjectModel>> GetAllAsync()
    {
        var projects = await context.Projects.AsNoTracking().ToListAsync();

        return projects;
    }

    public async Task<ProjectModel> CreateAsync(ProjectModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectModel> DeteleAsync(ProjectModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectModel> GetAsync(Expression<Func<ProjectModel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectModel> UpdateAsync(ProjectModel entity)
    {
        throw new NotImplementedException();
    }
}
