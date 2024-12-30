using FluxoDeCaixa.Infrastructure.Controller;

namespace FluxoDeCaixa.Infrastructure.Configuraction;

public static class ConnectionFactory
{
    public static Database GetDatabase() 
        => new Database(nameof(FluxoDeCaixa));
}
