using ProjetcManager.API.Data;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public ITaskRepository? _taskRepository;
    public IProjectRepository? _projectRepository;

    public ITaskRepository TaskRepository
    {
        get
        {
            return _taskRepository ??= new TaskRepository(_context);
        }
    }

    public IProjectRepository ProjectRepository
    {
        get
        {
            return _projectRepository ??= new ProjectRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
