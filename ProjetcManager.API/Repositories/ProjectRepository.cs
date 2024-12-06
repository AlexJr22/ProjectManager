using Microsoft.EntityFrameworkCore;
using ProjetcManager.API.Data;
using ProjetcManager.API.DTOs.Project;
using ProjetcManager.API.Models;
using ProjetcManager.API.Repositories;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API;

public class ProjectRepository(AppDbContext context)
    : Repository<ProjectModel>(context), IProjectRepository
{
    public async Task<IEnumerable<ProjectModel>> GetAllProjectsWithTasks()
    {
        var projects = await _context.Set<ProjectModel>()
            .Include(p => p.Tasks).AsNoTracking().ToListAsync();

        return projects;
    }
}
