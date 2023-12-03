using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Context;

public class TaskManagerContext : DbContext
{
    public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<UserTask> Tasks { get; set; }
    public DbSet<UserTaskHistory> TaskHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerContext).Assembly);
    }
}
