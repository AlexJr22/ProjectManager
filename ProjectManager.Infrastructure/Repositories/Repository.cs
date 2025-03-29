using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T>
    where T : class
{
    private readonly AppDbContext appDbContext = context;

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
    {
        var task = await appDbContext.Set<T>().FirstOrDefaultAsync(expression);

        return task;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var tasks = await appDbContext.Set<T>().AsNoTracking().ToListAsync();

        return tasks;
    }

    public async Task<T> CreateAsync(T entity)
    {
        await appDbContext.Set<T>().AddRangeAsync(entity);

        return entity;
    }

    public T Update(T entity)
    {
        appDbContext.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    public T Delete(T entity)
    {
        appDbContext.Remove(entity);

        return entity;
    }
}
