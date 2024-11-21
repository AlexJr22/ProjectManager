using ProjetcManager.API.Data;
using ProjetcManager.API.Models;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API.Repositories;

public class TaskRepository(AppDbContext context)
    : Repository<TaskModel>(context), ITaskRepository
{ }
