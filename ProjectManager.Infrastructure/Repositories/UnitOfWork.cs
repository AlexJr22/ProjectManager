using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class UnitOfWork(AppDbContext DbContext) : IUnitOfWork
{
    IProjectRepository? _projectRepository;
    private readonly AppDbContext context = DbContext;

    public IProjectRepository ProjectRepository
    {
        get { return _projectRepository ??= new ProjectRepository(context); }
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
