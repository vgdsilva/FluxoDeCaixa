using FluxoDeCaixa.Infrastructure.SQLite.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace FluxoDeCaixa.Infrastructure.SQLite.Persistence;

public class FluxoDeCaixaDbContext : DbContext
{
    public FluxoDeCaixaDbContext(DbContextOptions<FluxoDeCaixaDbContext> options)
    {
        // Aplica as migrações ao inicializar o contexto
        //Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=databaseDemo.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddEntities();

        base.OnModelCreating(modelBuilder);
    }
}

public static class ModelBuilderExtensions
{
    public static void AddEntities(this ModelBuilder modelBuilder)
    {
        IEnumerable<Type> typesToRegister = Array.Empty<Type>();
        foreach (Type entityType in typesToRegister)
        {
            new EntityMappingConfiguration(entityType).Map(modelBuilder);
        }
    }
}
