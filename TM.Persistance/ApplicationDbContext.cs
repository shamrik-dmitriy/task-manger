using Microsoft.EntityFrameworkCore;
using TM.Domain.Entities;
using TM.Domain.Entities.Category;
using TM.Domain.Entities.User;
using TM.Persistance.Configurations;
using Task = TM.Domain.Entities.Task.Task;

namespace TM.Persistance;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskType> TaskTypes { get; set; }
    public DbSet<Category> Categories { get; set; }

    private readonly DbContextOptions<ApplicationDbContext> _options;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _options = options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite("Filename=TM.Persistance.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BaseEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}