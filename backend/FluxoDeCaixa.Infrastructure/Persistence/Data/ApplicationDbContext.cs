using FluxoDeCaixa.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FluxoDeCaixa.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Obter todas as classes que herdam de EntityControl no assembly atual
            IEnumerable<Type> entityTypes = Assembly.GetAssembly(typeof(EntityControl))
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(EntityControl)));

            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
