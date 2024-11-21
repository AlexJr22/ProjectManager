namespace ProjetcManager.API.Repositories.interfaces;

public interface IUnitOfWork
{
    ITaskRepository TaskRepository { get; }
    Task CommitAsync();
    Task DisposeAsync();
}
