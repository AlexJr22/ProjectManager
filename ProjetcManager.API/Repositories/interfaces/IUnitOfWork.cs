namespace ProjetcManager.API.Repositories.interfaces;

public interface IUnitOfWork
{
    ITaskRepository TaskRepository { get; }
    IProjectRepository ProjectRepository { get; }
    Task CommitAsync();
    Task DisposeAsync();
}
