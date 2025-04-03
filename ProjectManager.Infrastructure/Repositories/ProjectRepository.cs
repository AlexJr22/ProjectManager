using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class ProjectRepository(AppDbContext DbContext)
    : Repository<ProjectModel>(DbContext),
        IProjectRepository
{
    public async Task<ProjectModel?> GetProjectWithTasksAsync(int id)
    {
       var project = await appDbContext.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id);

        return project;
    }
}
