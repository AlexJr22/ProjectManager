using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class TaskRepository : Repository<TaskModel>, ITaskRepository
{
    public TaskRepository(AppDbContext context)
        : base(context) { }
}
