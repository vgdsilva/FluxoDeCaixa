using FluxoDeCaixa.Data.Contexto;
using FluxoDeCaixa.Data.Geral;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data;

public abstract class AbstractRepository<T> where T : new()
{
    private readonly Type type = typeof(T);

    protected object[] GerarParametrosConsulta(params object[] lista)
    {
        return lista.ToArray();
    }

    //public List<T> Select<T> (string sql, object[] parameters = null) where T : new()
    //{
    //    try
    //    {
    //        using (SQLQuery conn = MobileContext.Instance.AssignNewInstanceSQLQuery())
    //        {
    //            var list = conn.Query<T>(sql, parameters ?? new object[0]);
    //            return list;
    //        }
    //    }
    //    catch ( Exception ex )
    //    {
    //        return new List<T>();
    //    }
    //}

    //public async Task<List<T>> SelectAsync<T>(string sql, object[] parameters = null) where T : new()
    //{
    //    try
    //    {
    //        var list = await MobileConnection.connectionAsync.QueryAsync<T>(sql, parameters ?? new object[0]);
    //        return list;
    //    }
    //    catch ( Exception ex )
    //    {
    //        return new List<T>();
    //    }
    //}

    //public T ExecuteScalar<T>(string sql, object[] parameters = null) where T : new()
    //{
    //    return MobileConnection.Connection.ExecuteScalar<T>(sql, parameters);
    //}

    //public async Task<T> ExecuteScalarAsync<T>(string sql, object[] parameters = null) where T : new()
    //{
    //    return await MobileConnection.connectionAsync.ExecuteScalarAsync<T>(sql, parameters);
    //}

    //public int ExecuteNomQuery(string sql, object[] parameters)
    //{
    //    SQLiteCommand command = MobileConnection.Connection.CreateCommand(sql, parameters);
    //    int resultado = command.ExecuteNonQuery();
    //    return resultado;
    //}
}
