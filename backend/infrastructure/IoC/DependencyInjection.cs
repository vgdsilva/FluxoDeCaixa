using FluxoDeCaixa.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, string ConnectionString)
        {
            ApplicationContext.AssignNewInstance(ConnectionString);
        }
    }
}
