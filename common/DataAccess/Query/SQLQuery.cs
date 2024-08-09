using SQLite;
using System.Collections;
using System.Text.RegularExpressions;
using System.Transactions;

namespace DataAccess;


public partial class SQLQuery : IDisposable
{
    /// <summary>Resultado da consulta SQL quando o SQLQuery for uma instrução SELECT</summary>
    public IList IListDadosConsulta { get; set; }

    public Dictionary<string, object> ParamByName { get; set; }

    /// <summary>Instrução SQL</summary>
    public string SQL { get; set; }

    public string ConnectionString { get; set; }


    public SQLQuery(string ConnectionString)
    {
        this.ConnectionString = ConnectionString;

        if ( ParamByName == null )
            ParamByName = new Dictionary<string, object>();
        ParamByName.Clear();
    }

    public void ClearAll()
    {
        SQL = null;

        if ( ParamByName != null )
            ParamByName.Clear();

        IListDadosConsulta = null;
    }

    public void Dispose()
    {
        if ( this == null )
            return;

        if ( IListDadosConsulta != null )
            IListDadosConsulta = null;

        if ( ParamByName != null )
            ParamByName.Clear();
        ParamByName = null;

        SQL = null;
    }

    public bool IsEmpty { get { return ( IListDadosConsulta?.Count ?? 0 ) == 0; } }


    /// <summary>
    /// Executa instrução INSERT, UPDATE ou DELETE
    /// </summary>
    /// <returns>Quantidade de registros afetados</returns>
    /// 
    public int ExecSQL()
    {
        return ExecSQL<Object>();
    }

    public int ExecSQL<T>()
    {

        using ( SQLiteConnection connection = new SQLiteConnection(ConnectionString) )
        {
            int rowsAffected = 0;

            SQLiteCommand CommandSmart = connection.CreateCommand(SQL);

            AtualizaParametrosSmart(CommandSmart); 

            rowsAffected = CommandSmart.ExecuteNonQuery();

            return rowsAffected;
        }
    }

    /// <summary>
    /// Preenche uma lista de T com os dados do retorno da execucao do SQL
    /// </summary>
    /// <typeparam name="T">Entidade que recebera as tuplas do BD</typeparam>
    /// <returns>Lista de T</returns>
    public List<T> Open<T>() where T : new()
    {
        return OpenSmart<T>();
    }


    /// <summary>
    /// Executa o SQL no banco de dados e retorna o primeiro resultado (se houver) 
    /// </summary>
    /// <typeparam name="T">Entidade que recebera a tupla do BD</typeparam>
    /// <returns>Instancia de T ou null</returns>
    public T OpenFirstOrDefault<T>() where T : new()
    {
        string _CleanSQL = Regex.Replace(SQL.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), @"\s+", " ").ToUpper();
        MatchCollection MatchLIMIT = Regex.Matches(SQL, @"(\sLIMIT\s)\d*");
        if ( MatchLIMIT.Count == 0 )
            this.SQL += " LIMIT 1 ";

        List<T> ListaDados = Open<T>();

        if ( ListaDados == null )
            ListaDados = new List<T>();

        return ListaDados.FirstOrDefault();
    }

    List<T> OpenSmart<T>() where T : new()
    {
        try
        {
            Type _Type = typeof(T);
            List<object> ListaObjects = AtualizaParametrosSmartERetornaListaParametros();
            List<T> listaDados = new List<T>();

            if (Domain.EntidadesUtils.IsPrimitiveOrEnum( _Type))
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    listaDados = OpenSmartPrimitiveType<T>(connection, ListaObjects, _Type);
                    IListDadosConsulta = listaDados;

                    return listaDados;
                }
            }
            else
            {
                using ( SQLiteConnection connection = new SQLiteConnection(ConnectionString) )
                {
                    listaDados = connection.Query<T>(SQL, ListaObjects.ToArray());
                    IListDadosConsulta = listaDados;

                    return listaDados;
                }
            }

        }
        catch ( Exception ex )
        {

            throw;
        }
    }

    private bool IsParametroIn(object Value)
    {
        return Value != null &&
               ( Value.GetType() == typeof(int[]) ||
                Value.GetType() == typeof(long[]) ||
                Value.GetType() == typeof(string[]) ||
                Value.GetType() == typeof(double[]) ||
                Value.GetType() == typeof(float[]) ||
                Value.GetType() == typeof(char[]) ||
                Value.GetType() == typeof(object[]) ||
                Value.GetType() == typeof(decimal[]) );
    }

    private object[] ConverteParametrosIN(object o)
    {
        Dictionary<Type, Delegate> processaType = new Dictionary<Type, Delegate>
            {
                { typeof(int[]), new Func<object, object[]>((object obj) => ((int[])obj).Select(s => (object)s).ToArray() ) },         //conversao para object[] inválida
                { typeof(long[]), new Func<object, object[]>((object obj) => ((long[])obj).Select(s => (object)s).ToArray() ) },         //conversao para object[] inválida
                { typeof(string[]), new Func<object, object[]>((object obj) => (object[])obj ) },                                      //conversao para object[] ok
                { typeof(double[]), new Func<object, object[]>((object obj) => ((double[])obj).Select(s => (object)s).ToArray() ) },   //conversao para object[] inválida
                { typeof(float[]), new Func<object, object[]>((object obj) => ((float[])obj).Select(s => (object)s).ToArray() ) },     //conversao para object[] inválida
                { typeof(char[]), new Func<object, object[]>((object obj) => ((char[])obj).Select(s => (object)s).ToArray() ) },       //conversao para object[] inválida
                { typeof(object[]), new Func<object, object[]>((object obj) => (object[])obj ) },                                      //conversao para object[] ok
                { typeof(decimal[]), new Func<object, object[]>((object obj) => ((decimal[])obj).Select(s => (object)s).ToArray() ) }, //conversao para object[] inválida
            };

        return (object[]) processaType[o.GetType()].DynamicInvoke(o);
    }
    void AtualizaParametrosSmart(SQLiteCommand CommandSmart)
    {
        foreach ( KeyValuePair<string, object> param in ParamByName )
        {
            if ( IsParametroIn(param.Value) )
            {
                object[] paramIN = ConverteParametrosIN(param.Value);

                string[] paramNames = paramIN.Select((s, i) => $"@{param.Key}{i}").ToArray();

                string vsIN = string.Join(",", paramNames);

                for ( int i = 0; i < paramNames.Length; i++ )
                {
                    object value = ( paramIN[i] == null ) ? DBNull.Value : ( ( paramIN[i] is string ) ? Regex.Replace(paramIN[i].ToString(), @"[^\x20-\xff-\x09-\x0a]+", "") : paramIN[i] );

                    CommandSmart.Bind($"@{paramNames[i]}", value);
                }
                SQL = SQL.Replace("@" + param.Key, vsIN);
                CommandSmart.CommandText = SQL;
            }
            else
            {
                CommandSmart.Bind($"@{param.Key}", param.Value);
            }
        }
    }


    List<object> AtualizaParametrosSmartERetornaListaParametros()
    {
        List<object> _ListaParameterValuesRetorno = new List<object>();

        foreach ( KeyValuePair<string, object> param in ParamByName )
        {
            if ( IsParametroIn(param.Value) )
            {
                object[] paramIN = ConverteParametrosIN(param.Value);

                string[] paramNames = paramIN.Select((s, i) => $"@{param.Key}{i}").ToArray();

                string vsIN = string.Join(",", paramNames);

                SQL = SQL.Replace("@" + param.Key, vsIN);
            }
        }

        this.SQL = Regex.Replace(SQL.Replace("\n", " ").Replace("\r", " ").Replace("\t", " "), @"\s+", " ");

        MatchCollection MatchesParametrosSQL = Regex.Matches(SQL, @"[@]\w*");

        for ( int i = 0; i < MatchesParametrosSQL.Count; i++ )
        {
            string _ParamNameComArroba = MatchesParametrosSQL[i].Value;
            SQL = SQL.Replace(_ParamNameComArroba, "?");

            if ( ParamByName.Any(x => x.Key.Equals(_ParamNameComArroba.Replace("@", ""), StringComparison.InvariantCultureIgnoreCase)) )
            {
                KeyValuePair<string, object> _ParameterSet = ParamByName.FirstOrDefault(x => x.Key.Equals(_ParamNameComArroba.Replace("@", ""), StringComparison.InvariantCultureIgnoreCase));
                _ListaParameterValuesRetorno.Add(_ParameterSet.Value);
            }
        }

        return _ListaParameterValuesRetorno;
    }

    List<T> OpenSmartPrimitiveType<T>(SQLiteConnection Connection, List<object> ListaObjects, Type _Type) where T : new()
    {
        List<T> listaDados = new List<T>();
        Type _RealType = Nullable.GetUnderlyingType(_Type);

        if ( _RealType == null )
        {
            listaDados.Add(Connection.ExecuteScalar<T>(SQL, ListaObjects.ToArray()));
        }
        else
        {
            T o = (T) Activator.CreateInstance(typeof(T));
            string result = Connection.ExecuteScalar<string>(SQL, ListaObjects.ToArray());

            if ( string.IsNullOrEmpty(result) )
            {
                listaDados.Add(o);
            }
            else
            {
                if ( _RealType.IsEnum )
                {
                    listaDados.Add((T) OpenSmartPrimitiveTypeGetEnumResult(_RealType, o, result));
                }
                else
                {
                    switch ( Type.GetTypeCode(_RealType) )
                    {
                        case TypeCode.Decimal:
                        case TypeCode.Double:
                            listaDados.Add((T) ( (object) Connection.ExecuteScalar<decimal>(SQL, ListaObjects.ToArray()) ));
                            break;
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                            listaDados.Add((T) (object) int.Parse(result));
                            break;
                        case TypeCode.Int64:
                            listaDados.Add((T) (object) long.Parse(result));
                            break;
                        case TypeCode.Boolean:
                            listaDados.Add((T) (object) ( "1".Equals(result) || "true".Equals(result.ToLower()) ));
                            break;
                        case TypeCode.DateTime:
                            listaDados.Add((T) ( (object) Connection.ExecuteScalar<DateTime>(SQL, ListaObjects.ToArray()) ));
                            break;
                        default:
                            listaDados.Add(Connection.ExecuteScalar<T>(SQL, ListaObjects.ToArray()));
                            break;
                    }
                }
            }
                
        }

        return listaDados;
    }

    object OpenSmartPrimitiveTypeGetEnumResult(Type _RealType, object NullableNewInstance, string result)
    {
        int enumValue;
        if ( int.TryParse(result, out enumValue) )
        {
            if ( _RealType.IsEnumDefined(enumValue) )
            {
                return Enum.Parse(_RealType, result);
            }
            else
                return NullableNewInstance;
        }
        else
        {
            if ( _RealType.IsEnumDefined(result) )
                return Enum.Parse(_RealType, result);
            else
                return NullableNewInstance;
        }
    }
}
