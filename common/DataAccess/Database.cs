using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DataAccess;
public class Database
{
    public string ConnectionString { get; set; }

    public Database(string ConnectionString)
    {
        this.ConnectionString = ConnectionString;  
    }

    public static void CreateDatabaseFile(string path)
    {
        var s = new SQLiteConnection(path, SQLiteOpenFlags.Create);
    }

    public T Get<T>(object ID) where T : new()
    {
        using (SQLQuery Query = new SQLQuery(ConnectionString))
        {
            Query.SQL = $@"SELECT * FROM {GetEntityName(typeof(T))} WHERE {GetEntityIDName(typeof(T))} = {ID}".ToUpper();
            return Query.OpenFirstOrDefault<T>();
        }
    }

    public List<T> GetAll<T>() where T : new()
    {
        using (SQLQuery Query = new SQLQuery(ConnectionString))
        {
            Query.SQL = $@"SELECT * FROM {GetEntityName(typeof(T))}".ToUpper();
            return Query.Open<T>();
        }
    }

    public List<T> Query<T>(string sql) where T : new()
    {
        using ( SQLQuery query = new SQLQuery(ConnectionString) )
        {
            query.SQL = sql;
            return query.Open<T>();
        }
    }

    public void Execute(string sql)
    {
        using (SQLQuery query = new SQLQuery(ConnectionString))
        {
            query.SQL = sql;
            query.ExecSQL();
        }
    }

    string GetEntityName(Type type)
    {
        return type.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.TableAttribute>()?.Name ?? type.Name;
    }

    string GetEntityIDName(Type type)
    {
        var pi = PropertyUtils.GetPropertyID(type);
        return pi.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.ColumnAttribute>()?.Name ?? pi.Name;
    }
}
