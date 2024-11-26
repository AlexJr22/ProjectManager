using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetcManager.API.Models;

namespace ProjetcManager.API.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }
    
    public DbSet<ProjectModel>? Projects { get; set; }
    public DbSet<TaskModel>? TaskSTable { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProjectModel>().HasKey(c => c.Id);
        modelBuilder.Entity<TaskModel>().HasKey(c => c.Id);

        modelBuilder.Entity<TaskModel>()
            .HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
