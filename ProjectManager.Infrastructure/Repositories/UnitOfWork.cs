using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(AppDbContext dbContext)
    {
        context = dbContext;
    }

    private readonly AppDbContext context;
    IProjectRepository? _projectRepository;
    ITaskRepository? _taskRepository;

    public IProjectRepository ProjectRepository
    {
        get { return _projectRepository ??= new ProjectRepository(context); }
    }

    public ITaskRepository TaskRepository
    {
        get { return _taskRepository ??= new TaskRepository(context); }
    }

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await context.DisposeAsync();
    }
}
