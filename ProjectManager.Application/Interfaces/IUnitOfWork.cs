using ProjectManager.Domain.Interfaces;

namespace ProjectManager.Application.Interfaces;

public interface IUnitOfWork
{
    IProjectRepository ProjectRepository { get; }

    Task CommitAsync();
    Task DisposeAsync();
}
