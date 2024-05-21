using DataAccessObject.SQLite;
using FluxoDeCaixa.Commun.Entities;
using FluxoDeCaixa.Core.Utils.Classes;

namespace FluxoDeCaixa.Core.Configuration;

public class Factory
{

    public static string GetFolderDatabasePath() => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    public static string databasePath = Path.Combine(GetFolderDatabasePath(), "database.db");
    public static string databaseSample = "databaseSample.db";

    public static void InitInstanceDatabase()
    {
        if (!ExistsDatabase())
        {
            DatabaseConfiguration configuration = CreateDatabaseConfiguration();
            configuration.SynchronizeTables();
        }
    }

    public static DatabaseConfiguration CreateDatabaseConfiguration()
    {
        DatabaseConfiguration configuration = new DatabaseConfiguration(databasePath, dce =>
        {
            dce.RegisterTable<User>();
            dce.RegisterTable<Operation>();
        });

        return configuration;
    }
        

    public static Database GetDatabase() => 
        CreateDatabaseConfiguration().CreateDatabase();

    public static bool ExistsDatabase() => File.Exists(databasePath);
}
