using FluxoDeCaixa.Data;

namespace FluxoDeCaixa.Core.Configuration;

public class Factory
{
    public static Database GetDatabase(string databaseName) => new Database(databaseName);
}
