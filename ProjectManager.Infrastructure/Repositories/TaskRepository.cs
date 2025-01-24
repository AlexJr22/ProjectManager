using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class TaskRepository(AppDbContext context) : ITaskRepository
{
    private readonly AppDbContext context = context;

    public async Task<IEnumerable<TaskModel>> GetAllAsync()
    {
        var tasks = await context.Tasks.AsNoTracking().ToListAsync();

        return tasks ?? Enumerable.Empty<TaskModel>();
    }

    public async Task<TaskModel> GetAsync(Expression<Func<TaskModel, bool>> expression)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(expression);

        return task!;
    }

    public async Task<TaskModel> CreateAsync(TaskModel entity)
    {
        await context.Tasks.AddAsync(entity);

        return entity;
    }

    public TaskModel Update(TaskModel entity)
    {
        context.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    public  TaskModel Delete(TaskModel entity)
    {
        context.Tasks.Remove(entity);

        return entity;
    }
}
