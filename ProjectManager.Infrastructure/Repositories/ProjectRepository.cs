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

    public async Task<ProjectModel>? GetAsync(Expression<Func<ProjectModel, bool>> expression)
    {
        var project = await context.Projects.FirstOrDefaultAsync(expression);

        return project!;
    }

    public async Task<ProjectModel> CreateAsync(ProjectModel entity)
    {
        await context.Projects.AddRangeAsync(entity);

        return entity;
    }

    public ProjectModel Update(ProjectModel entity)
    {
        context.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    public ProjectModel Detele(ProjectModel entity)
    {
        context.Projects.Remove(entity);

        return entity;
    }
}
