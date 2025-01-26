using FluxoDeCaixa.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa.Data;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, SQLiteDatabaseConfiguration configuration)
    {
        return services
            .RegisterPersistence(configuration)
            .RegisterRepositories();
    }

    private static IServiceCollection RegisterPersistence(this IServiceCollection services, SQLiteDatabaseConfiguration configuration)
    {
        return services
            .AddSingleton(configuration)
            .AddTransient<DbConnection>();
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient<TransactionRepository>()
            .AddTransient<CategoryRepository>();
    }
}
