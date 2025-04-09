namespace ProjectManager.Domain.Interfaces;

public interface IUnitOfWork
{
    IProjectRepository ProjectRepository { get; }
    ITaskRepository TaskRepository { get; }

    Task CommitAsync();
    Task DisposeAsync();
}
