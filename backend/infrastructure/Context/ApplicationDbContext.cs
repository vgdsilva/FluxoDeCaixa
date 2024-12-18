using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Principal;

namespace FluxoDeCaixa.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Obter todas as classes que herdam de EntityControl no assembly atual
        IEnumerable<Type> entityTypes = GetEntities();

        foreach (var type in entityTypes)
        {
            modelBuilder.Entity(type);
        }

        base.OnModelCreating(modelBuilder);
    }


    private static IEnumerable<Type> GetEntities()
    {
        return Assembly
            .Load(new AssemblyName("FluxoDeCaixa.Domain"))
            .GetTypes()
            .Where(t => string.Equals(t.Namespace, typeof(Usuario).Namespace, StringComparison.Ordinal))
            .Where(t => typeof(EntityControl).IsAssignableFrom(t) && !t.IsAbstract);
    }
}
