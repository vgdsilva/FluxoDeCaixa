using FluxoDeCaixa.Data.Geral;
using SQLite;

namespace FluxoDeCaixa.Data.Repository;

public class Repository
{
    #region Variaveis

    public SQLiteConnectionWithLock Connection { get { return MobileConnection.Connection; } }
    public SQLiteAsyncConnection ConnectionAsync { get { return MobileConnection.connectionAsync; } }

    #endregion

    #region Select

    public List<T> Select<T>(string query, object[] parameters = null) where T : new()
    {
		try
		{
			parameters = parameters ?? new object[0];

			return Connection.Query<T>(query, parameters);
		}
		catch (Exception ex)
		{
			return new List<T>();
		}
    }
	
	public async Task<List<T>> SelectAsync<T>(string query, object[] parameters = null) where T : new()
    {
		try
		{
			parameters = parameters ?? new object[0];

			List<T> result = await ConnectionAsync.QueryAsync<T>(query, parameters);
			return result;
		}
		catch (Exception ex)
		{
			return new List<T>();
		}
    }

    #endregion

    #region ExecuteScalar

    public T ExecuteScalar<T>(string sql, object[] parameters = null) where T : new()
	{
		return Connection.ExecuteScalar<T>(sql, parameters);
	}

    public async Task<T> ExecuteScalarAsync<T>(string sql, object[] parameters = null) where T : new()
    {
        return await ConnectionAsync.ExecuteScalarAsync<T>(sql, parameters);
    }

    #endregion

    #region ExecuteNonQuery

    public int ExecuteNomQuery(string sql, params object[] parameters)
    {
        SQLiteCommand command = Connection.CreateCommand(sql, parameters);
        int resultado = command.ExecuteNonQuery();

        return resultado;
    }

    #endregion

    #region Delete

    public int Delete(string table, long id)
    {
        return ExecuteNomQuery($"DELETE FROM {table.ToUpper()} WHERE ID{table.ToUpper()} = ?", id);
    }

    #endregion

    #region Funções

    private const string COM_ACENTOS = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
    private const string SEM_ACENTOS = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

    private string RemoveAcentos(string texto)
    {
        foreach ( char c in COM_ACENTOS )
            texto = texto.Replace(c, SEM_ACENTOS[COM_ACENTOS.IndexOf(c)]);
        return texto;
    }

    #endregion
}
