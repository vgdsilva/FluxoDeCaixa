using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Migration.Context;

public class SQLiteContext : DbContext
{

    public DbSet<User> User { get; set; }

    public SQLiteContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
