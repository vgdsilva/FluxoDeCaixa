using SQLite;

namespace FluxoDeCaixa.Data.Geral;

public class MobileConnection
{
    public static SQLiteConnectionWithLock _connection;

    public static SQLiteConnectionWithLock Connection
    {
        get
        {
            try
            {
                if (_connection == null || _connection.DatabasePath != "" || _connection.Handle == null)
                {
                    _connection.Close();
                }

                return _connection;
            }
            catch ( Exception ex )
            {
                return _connection;
            }
        }
    }

    public static SQLiteConnectionWithLock CriarNovaConexao()
    {
        SQLiteConnectionWithLock connectionLock = connectionAsync?.GetConnection();

        if ( connectionLock?.Handle == null )
        {
            _connectionAsync = null;
            connectionLock = connectionAsync?.GetConnection();
        }
        return connectionLock;
    }

    public static void CloseConnection()
    {
        if ( _connectionAsync != null )
        {
            _connectionAsync.GetConnection().Close();
            _connectionAsync.GetConnection().Dispose();
            SQLiteAsyncConnection.ResetPool();
            _connectionAsync = null;
        }

        if ( _connection?.Handle != null )
        {
            if ( _connection.IsInTransaction )
                _connection.Rollback();

            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }

    private static SQLiteAsyncConnection _connectionAsync;
    public static SQLiteAsyncConnection connectionAsync
    {
        get
        {
            if ( _connectionAsync == null || _connectionAsync.GetConnection().Handle == null )
                _connectionAsync = CriaNovaConexaoAsync();

            return _connectionAsync;
        }
    }

    private static SQLiteAsyncConnection CriaNovaConexaoAsync()
    {
        //if ( MobileContext.Instance?.databasePath == null )
        //    return null;

        return new SQLiteAsyncConnection(/*MobileContext.Instance.databasePath*/"", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex, false);
    }
}
