using FluxoDeCaixa.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, string ConnectionString)
        {
            SessionContext.AssignNewInstance(ConnectionString);
        }
    }
}
