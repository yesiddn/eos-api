using Domain;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Task;

namespace Infrastructure;

public class EosContext : DbContext
{
    public EosContext(DbContextOptions<EosContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Auth> Auths { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<Task> Tasks { get; set; }
}
