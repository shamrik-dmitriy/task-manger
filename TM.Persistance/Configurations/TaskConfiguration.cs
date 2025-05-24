using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TM.Domain.Entities.Task.Task;

namespace TM.Persistance.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Tasks");
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.StartDate).HasDefaultValueSql("datetime('now')").IsRequired();
        builder.Property(x => x.EndDate).HasDefaultValueSql("datetime('now', '+1 day')").IsRequired();
        
        builder.Property(x => x.TaskStatus).HasConversion<string>();
    }
}