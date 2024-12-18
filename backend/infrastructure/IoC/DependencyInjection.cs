using FluxoDeCaixa.Infrastructure.Context;
using FluxoDeCaixa.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));

            ApplicationContext.AssignNewInstance(configuration.GetConnectionString("PostgreSQL"));
        }
    }
}
