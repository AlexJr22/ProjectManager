using Microsoft.EntityFrameworkCore;
using ProjetcManager.API.Data;
using ProjetcManager.API.Models;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API.Repositories;

public class TaskRepository(AppDbContext context)
    : Repository<TaskModel>(context), ITaskRepository
{
    public async Task<IEnumerable<TaskModel>> GetTaskWithProjects()
    {
        var tasks = await _context.Set<TaskModel>().Include(c => c.Project).AsNoTracking().ToListAsync();

        return tasks;
    }
}
