using SQLite;
using System.Diagnostics;

namespace FluxoDeCaixa.Data;

public class Database : IDisposable
{
    private SQLiteConnection Connection { get; set; }

    public Database(string StringConnection)
    {
        Connection = new SQLiteConnection(StringConnection);
    }

    public void ExecuteNonQuery(string SQL)
    {
        ExecuteNonQuery<Object>(SQL);
    }

    public int ExecuteNonQuery<T>(string SQL)
    {
        int rowsAffected;

        var CommandSmart = Connection.CreateCommand(SQL);

        rowsAffected = CommandSmart.ExecuteNonQuery();

        return rowsAffected;
    }

    public List<T> QueryList<T>(string SQL) where T : new()
    {
        try
        {
            Type _Type = typeof(T);
            List<T> listaDados = new List<T>();

            using ( SQLiteConnection conn = Connection )
            {
                listaDados = conn.Query<T>(SQL);
                return listaDados;
            }
            
        }
        catch ( Exception ex )
        {
            Debug.WriteLine("/!\\ {0}: Erro ao executar a SQL: {1}", new object[] { ex.Message, SQL });
            throw ex;
        }
    }

    public T QueryFirstOrDefault<T>(string SQL) where T : new()
    {
        var resultados = QueryList<T>(SQL);
        return resultados.FirstOrDefault();
    }

    public void Dispose()
    {
        
    }
}
