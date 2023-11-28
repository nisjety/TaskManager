using Microsoft.EntityFrameworkCore;
using TaskManager.models;

namespace TaskManager.database;

public class DatabaseContext : DbContext
{
    public DbSet<User> User => Set<User>();
    public DbSet<UTask> UTask => Set<UTask>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=database/TaskManager.db");
    }
}