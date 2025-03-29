using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Interfaces;
using ProjectManager.Infrastructure.Context;

namespace ProjectManager.Infrastructure.Repositories;

public class ProjectRepository(AppDbContext DbContext)
    : Repository<ProjectModel>(DbContext),
        IProjectRepository { }
