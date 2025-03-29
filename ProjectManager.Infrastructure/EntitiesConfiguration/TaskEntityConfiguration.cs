using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infrastructure.EntitiesConfiguration;

public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskModel>
{
    public void Configure(EntityTypeBuilder<TaskModel> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .HasOne(t => t.Project)
            .WithMany(t => t.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t => t.CreateAt)
            .HasDefaultValueSql("GETUTCDATE")
            .ValueGeneratedOnAdd();
    }
}
