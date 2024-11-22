using ProjetcManager.API.Data;
using ProjetcManager.API.Models;
using ProjetcManager.API.Repositories;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API;

public class ProjectRepository(AppDbContext context)
    : Repository<ProjectModel>(context), IProjectRepository
{ }
