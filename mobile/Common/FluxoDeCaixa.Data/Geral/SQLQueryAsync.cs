using FluxoDeCaixa.Data.Contexto;
using SQLite;

namespace FluxoDeCaixa.Data.Geral;

public partial class SQLQuery : IDisposable
{

    public async Task<List<T>> QueryAsync<T>(string sql, object[] parameters) where T : new()
    {
        SQLiteAsyncConnection conn = new SQLiteAsyncConnection(ConnectionString);        
        
        var list = await conn.QueryAsync<T>(sql, parameters ?? new object[0]);
        
        return list;
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object[] parameters) where T : new()
    {
        SQLiteAsyncConnection conn = new SQLiteAsyncConnection(ConnectionString);

        List<T> list = await conn.QueryAsync<T>(sql, parameters ?? new object[0]) ?? new List<T>();
        
        return list.FirstOrDefault();
    }
}
