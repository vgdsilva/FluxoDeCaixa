using Npgsql;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FluxoDeCaixa.Infrastructure.Controller;

public class SQLQuery : IDisposable
{

    private string ConnectionString { get; set; }

    /// <summary>
    /// Instrução SQL
    /// </summary>
    public string SQL { get; set; }

    /// <summary>
    /// Resultado da consulta SQL quando o SQLQuery for uma instrução SELECT
    /// </summary>
    public DataTable dtDados { get; set; }

    public Dictionary<string, object> ParamByName { get; set; }

    private IDbCommand objCommand { get; set; }
    private NpgsqlDataAdapter objDataAdapter { get; set; }
    private NpgsqlCommandBuilder objCommandBuilder { get; set; }

    public long TempoDeExecucao { get; private set; }


    public SQLQuery(string connectionString)
    {
        ConnectionString = connectionString;

        if (ParamByName == null)
            ParamByName = new Dictionary<string, object>();
        ParamByName.Clear();
    }

    public void ClearAll()
    {
        SQL = null;

        if (ParamByName != null)
            ParamByName.Clear();
    }

    public void ClearParameters()
    {
        ParamByName.Clear();
    }

    public object GetParamByName(string Name)
    {
        if (ParamByName.ContainsKey(Name))
            return ParamByName[Name];

        return null;
    }

    private bool IsParametroIn(object Value)
    {
        return Value != null &&
               (Value.GetType() == typeof(int[]) ||
                Value.GetType() == typeof(string[]) ||
                Value.GetType() == typeof(double[]) ||
                Value.GetType() == typeof(float[]) ||
                Value.GetType() == typeof(char[]) ||
                Value.GetType() == typeof(object[]) ||
                Value.GetType() == typeof(long[]) ||
                Value.GetType() == typeof(decimal[]));
    }

    private object[] ConverteParametrosIN(object o)
    {
        Dictionary<Type, Delegate> processaType = new Dictionary<Type, Delegate>
            {
                { typeof(int[]), new Func<object, object[]>((object obj) => ((int[])obj).Select(s => (object)s).ToArray() ) },         //conversao para object[] inválida
                { typeof(string[]), new Func<object, object[]>((object obj) => (object[])obj ) },                                      //conversao para object[] ok
                { typeof(double[]), new Func<object, object[]>((object obj) => ((double[])obj).Select(s => (object)s).ToArray() ) },   //conversao para object[] inválida
                { typeof(float[]), new Func<object, object[]>((object obj) => ((float[])obj).Select(s => (object)s).ToArray() ) },     //conversao para object[] inválida
                { typeof(char[]), new Func<object, object[]>((object obj) => ((char[])obj).Select(s => (object)s).ToArray() ) },       //conversao para object[] inválida
                { typeof(object[]), new Func<object, object[]>((object obj) => (object[])obj ) },                                      //conversao para object[] ok
                { typeof(decimal[]), new Func<object, object[]>((object obj) => ((decimal[])obj).Select(s => (object)s).ToArray() ) }, //conversao para object[] inválida
                { typeof(long[]), new Func<object, object[]>((object obj) => ((long[])obj).Select(s => (object)s).ToArray() ) },
            };

        return (object[])processaType[o.GetType()].DynamicInvoke(o);
    }

    private void AtualizaParametros()
    {
        //"tenta" escapar sql injection
        objCommand.CommandText = objCommand.CommandText.Replace(";", "");

        foreach (KeyValuePair<string, object> param in ParamByName)
        {
            if (!SQL.Contains("@" + param.Key))
                Debug.WriteLine("~~~ O parâmetro {0} não consta na SQL: {1}", new object[] { "@" + param.Key, objCommand.CommandText });

            if (IsParametroIn(param.Value))
            {
                object[] paramIN = ConverteParametrosIN(param.Value);

                string[] paramNames = paramIN.Select((s, i) => string.Format("@{0}{1}", param.Key, i)).ToArray();

                string vsIN = string.Join(",", paramNames);

                for (int i = 0; i < paramNames.Length; i++)
                {
                    IDbDataParameter parametro = objCommand.CreateParameter();
                    parametro.ParameterName = paramNames[i];

                    parametro.Value = (paramIN[i] == null) ? DBNull.Value : ((paramIN[i] is string) ? Regex.Replace(paramIN[i].ToString(), @"[^\x20-\xff-\x09-\x0a]+", "") : paramIN[i]);

                    objCommand.Parameters.Add(parametro);
                }
                SQL = SQL.Replace("@" + param.Key, vsIN);
                objCommand.CommandText = SQL;
            }
            else
            {
                IDbDataParameter parametro = objCommand.CreateParameter();
                parametro.ParameterName = param.Key;

                parametro.Value = (param.Value == null) ? DBNull.Value : ((param.Value is string) ? Regex.Replace(param.Value.ToString(), @"[^\x20-\xff-\x09-\x0a]+", "") : param.Value);

                objCommand.Parameters.Add(parametro);
            }
        }
    }



    /// <summary>
    /// Executa instrução INSERT, UPDATE ou DELETE
    /// </summary>
    /// <returns>Quantidade de registros afetados</returns>
    public int ExecSQL()
    {

        using (DbConnection conn = ConnectionFactory.CreateConnection(ConnectionString))
        {
            objCommand = new NpgsqlCommand(SQL, conn.Connection);

            var transaction = conn.BeginTransaction();
            objCommand.Transaction = transaction;

            AtualizaParametros();

            int viRetorno = 0;

            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                viRetorno = objCommand.ExecuteNonQuery();

                stopwatch.Stop();

                TempoDeExecucao = stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objCommand.Dispose();
            }

            return viRetorno;
        }
    }

    public void Dispose()
    {
        ClearAll();
    }
}
