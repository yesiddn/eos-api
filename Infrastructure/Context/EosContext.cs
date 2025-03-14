using Domain;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace Infrastructure;

public class EosContext : DbContext
{
    public EosContext(DbContextOptions<EosContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Auth> Auths { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Priority> Priorities { get; set; } = null!;
    public DbSet<Task> Tasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Task>()
            .HasOne(t => t.Priority)
            .WithMany()
            .HasForeignKey(t => t.PriorityId)
            .OnDelete(DeleteBehavior.NoAction); // Evitar conflicto de eliminación en cascada

        modelBuilder
            .Entity<Task>()
            .HasOne(t => t.Group)
            .WithMany()
            .HasForeignKey(t => t.GroupId)
            .OnDelete(DeleteBehavior.Cascade); // Si está bien, deja este en cascada

        modelBuilder
            .Entity<Task>()
            .HasOne(t => t.ParentTask)
            .WithMany(t => t.SubTasks)
            .HasForeignKey(t => t.ParentTaskId)
            .OnDelete(DeleteBehavior.NoAction); // Evitar conflicto

        modelBuilder
            .Entity<Task>()
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
