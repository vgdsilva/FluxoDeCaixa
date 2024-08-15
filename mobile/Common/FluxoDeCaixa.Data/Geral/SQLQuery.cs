using FluxoDeCaixa.Data.Contexto;
using SQLite;

namespace FluxoDeCaixa.Data.Geral;

public partial class SQLQuery : IDisposable
{
    public string ConnectionString { get; private set; }

    private readonly SQLiteConnection _connection;


    public SQLQuery(string ConnectionString)
    {
        this.ConnectionString = ConnectionString;
    }


    public List<T> Query<T>(string sql, object[] parameters) where T : new()
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            var list = conn.Query<T>(sql, parameters ?? new object[0]);
            return list;
        }
    }
    
    public T QueryFirstOrDefault<T>(string sql, object[] parameters = null) where T : new()
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            var list = conn.Query<T>(sql, parameters ?? new object[0]);
            return list.FirstOrDefault();
        }
    }


    public T ExecuteScalar<T>(string sql, object[] parameters = null) where T : class
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            return conn.ExecuteScalar<T>(sql, parameters ?? new object[0]);
        }   
    }

    public void ExecuteNonQuery(string sql, object[] objects = null)
    {
        using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
        {
            try
            {
                conn.BeginTransaction();

                string[] comandos = sql.Split(";");

                foreach (string comando in comandos)
                {
                    string comandoAux = comando.Trim();
                    if (string.IsNullOrEmpty(comandoAux))
                        continue;

                    SQLiteCommand command = conn.CreateCommand(comandoAux, objects ?? new object[0]);
                    command.CommandText = comandoAux;
                    command.ExecuteNonQuery();
                }

                conn.Commit();
            }
            catch (Exception ex)
            {
                conn.Rollback();
            }
        }
    }

    public void Dispose()
    {
        
    }
}
