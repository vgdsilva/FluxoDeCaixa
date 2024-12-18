using Npgsql;
using System.Data;

namespace FluxoDeCaixa.Infrastructure.Controller
{
    public class DbConnection : IDisposable
    {
        
        private readonly NpgsqlConnection _connection;

        private IDbTransaction? _transaction;


        public DbConnection(string ConnectionString)
        {
            _connection = new NpgsqlConnection(ConnectionString);
            _connection.Open();
        }

        public DbConnection(NpgsqlConnection Connection)
        {
            this._connection = Connection;
        }

        public NpgsqlConnection Connection => _connection;

        public IDbTransaction BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction = null;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection.Close(); // Fecha a conexão
            _connection.Dispose();
        }
    }
}
