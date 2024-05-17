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
        if ( !File.Exists(databasePath) )
        {
            //FileUtils.CopyResourceMobileIfNotExists(typeof(App), databaseSample, databasePath);

            DatabaseConfiguration configuration = CreateDatabaseConfiguration();

            configuration.CreateDatabase();
        }
    }

    public static DatabaseConfiguration CreateDatabaseConfiguration()
    {
        DatabaseConfiguration configuration = new DatabaseConfiguration(databasePath, dce =>
        {
            dce.RegisterTable<User>();
            dce.RegisterTable<Transaction>();
        });

        return configuration;
    }
        

    public static Database GetDatabase() => 
        CreateDatabaseConfiguration().CreateDatabase();
}
