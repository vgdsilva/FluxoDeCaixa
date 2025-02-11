using System.Data;
using System.Data.SQLite;

namespace FluxoDeCaixa.Data.Conexao;

public class ConexaoSQLite : IDisposable
{
    private readonly SQLiteConnection _connection;
    private bool _disposed = false;

    public ConexaoSQLite(string connectionString)
    {
        _connection = new SQLiteConnection(connectionString);
        _connection.Open();
    }

    /// <summary>
    /// Executa comandos que não retornam dados (INSERT, UPDATE, DELETE)
    /// </summary>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public int ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
    {
        EnsureNotDisposed();
        using var command = new SQLiteCommand(query, _connection);
        AddParameters(command, parameters);
        return command.ExecuteNonQuery();
    }

    /// <summary>
    /// Executa comandos que retornam um único valor (Ex: COUNT, MAX, SUM)
    /// </summary>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public object? ExecuteScalar(string query, Dictionary<string, object>? parameters = null)
    {
        EnsureNotDisposed();
        using var command = new SQLiteCommand(query, _connection);
        AddParameters(command, parameters);
        return command.ExecuteScalar();
    }

    /// <summary>
    /// Adiciona parâmetros às consultas para evitar SQL Injection
    /// </summary>
    /// <param name="command"></param>
    /// <param name="parameters"></param>
    private static void AddParameters(SQLiteCommand command, Dictionary<string, object>? parameters)
    {
        if (parameters == null) return;
        foreach (var param in parameters)
        {
            command.Parameters.AddWithValue(param.Key, param.Value);
        }
    }

    /// <summary>
    ///     Executa SELECT e retorna os resultados como um DataTable
    /// </summary>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public DataTable Query(string query, Dictionary<string, object>? parameters = null)
    {
        EnsureNotDisposed();
        using var command = new SQLiteCommand(query, _connection);
        AddParameters(command, parameters);
        using var reader = command.ExecuteReader();

        var dataTable = new DataTable();
        dataTable.Load(reader);
        return dataTable;
    }

    /// <summary>
    /// Método que garante que a classe não seja usada após ser descartada
    /// </summary>
    /// <exception cref="ObjectDisposedException"></exception>
    private void EnsureNotDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(ConexaoSQLite));
        }
    }

    /// Implementação do padrão Dispose
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();
            }
            _disposed = true;
        }
    }

    /// <summary>
    /// Chamado automaticamente quando usado com "using"
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Finalizador para garantir que os recursos sejam liberados
    /// </summary>
    ~ConexaoSQLite()
    {
        Dispose(false);
    }
}
