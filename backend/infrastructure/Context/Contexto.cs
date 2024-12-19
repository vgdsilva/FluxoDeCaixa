using FluxoDeCaixa.Infrastructure.Controller;

namespace FluxoDeCaixa.Infrastructure.Context;

public class Contexto
{
    public static Contexto Instance { get; private set; }

    public string ConnectionString { get; private set; }

    public static void AssignNewInstance(string connectionString)
    {
        Instance = new Contexto()
        {
            ConnectionString = connectionString
        };
    }


    public SQLQuery SQLQueryNewInstance() => new SQLQuery(ConnectionString);
}
