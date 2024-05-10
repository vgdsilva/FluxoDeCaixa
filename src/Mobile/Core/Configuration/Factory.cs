using FluxoDeCaixa.Data;

namespace FluxoDeCaixa.Core.Configuration;

public class Factory
{

    public static string GetFolderDatabasePath() => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    public static string databasePath = Path.Combine(GetFolderDatabasePath(), "database.db");
    public static Database GetDatabase() => new Database(databasePath);
}
