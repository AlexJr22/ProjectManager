using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infrastructure.Context;

internal class AppDbContext(DbContextOptions options) : DbContext(options)
{
    DbSet<ProjectModel>? Projects { get; set; }
    DbSet<TaskModel>? Tasks { get; set; }
}
