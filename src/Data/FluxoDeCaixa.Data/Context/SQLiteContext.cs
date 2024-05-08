using FluxoDeCaixa.Commun.ValueObjects;
using FluxoDeCaixa.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoDeCaixa.Data.Context;

public class SQLiteContext : DbContext
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entityTypes = Util.GetTypes(typeof(Entity));

        // Adiciona cada tipo de entidade como um DbSet genérico
        foreach ( var entityType in entityTypes )
        {
            // Obtém o método genérico modelBuilder.Entity<TEntity>() correspondente ao tipo de entidade
            var entityMethod = modelBuilder.GetType().GetMethod(nameof(ModelBuilder.Entity), Type.EmptyTypes)
                .MakeGenericMethod(entityType);

            // Invoca o método para adicionar o DbSet ao contexto
            entityMethod.Invoke(modelBuilder, null);
        }
    }
}
