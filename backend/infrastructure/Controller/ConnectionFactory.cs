using Npgsql;
using System.Data;

namespace FluxoDeCaixa.Infrastructure.Controller;

public static class ConnectionFactory
{
    public static DbConnection CreateConnection(string ConnectionString)
    {
        return new DbConnection(new NpgsqlConnection(ConnectionString));
    }
}
