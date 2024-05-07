using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Data;

public class AppContext
{

    static AppContext _instance;

    public static AppContext Instance 
    { 
        get 
        { 
            return _instance ?? new AppContext(); 
        } 
    }

    public static string GetFolderDatabasePath() => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    public static string databasePath = Path.Combine(GetFolderDatabasePath(), "database.db");

    public Database GetDatabase() => new Database(databasePath);

    public bool IsValidContext()
    {



        return false;
    }

    public async Task InitInstanceDB()
    {

        //Create database
        File.Create(databasePath);

        // Obtém o assembly atual
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Obtém todos os nomes de recursos no assembly atual
        string[] allResourceNames = assembly.GetManifestResourceNames();

        // Filtra os nomes de recursos que estão no diretório "FluxoDeCaixa.Mobile.Core.Data.Scripts" e terminam com ".sql"
        var sqlResourceNames = allResourceNames.Where(n => n.StartsWith("FluxoDeCaixa.Mobile.Core.Data.Scripts") && n.EndsWith(".sql")).ToList();

        // Para cada arquivo .sql encontrado, ler e executar
        foreach ( var resourceName in sqlResourceNames )
        {
            // Lê o conteúdo do recurso
            using ( Stream stream = assembly.GetManifestResourceStream(resourceName) )
            {
                if ( stream == null )
                {
                    continue;
                    //throw new ArgumentException($"Recurso '{resourceName}' não encontrado.");
                }

                using ( StreamReader reader = new StreamReader(stream) )
                {
                    string sqlScript = reader.ReadToEnd();
                    // Implemente a lógica para processar o script SQL aqui
                    Console.WriteLine("Executando script SQL:");
                    Console.WriteLine(sqlScript);
                    Console.WriteLine("Fim do script SQL.");
                }
            }
        }
    }

    List<Dictionary<string, string>> getAllMigrations()
    {
        List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

        Assembly defaultAssembly = typeof(App).Assembly;
        var pathAssembly = defaultAssembly.GetManifestResourceNames().Where(x => x.StartsWith("FluxoDeCaixa.Mobile.Core.Data.Scripts")).ToList();
        
        foreach ( var resourceName in pathAssembly )
        {

        }


        return list;
    }
}
