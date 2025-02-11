using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;

namespace FluxoDeCaixa.Data.Persistence
{
    public class SQLiteDatabase : IDisposable
    {
        private SqliteConnection _connection;

        public SQLiteDatabase(string databasePath)
        {
            _connection = new SqliteConnection($"DataSource={databasePath}");
            _connection.Open();
        }

        public IEnumerable<T> Query<T>(string sql, Dictionary<string, object> parameters = null) where T : new()
        {
            var command = new SqliteCommand(sql, _connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)).ToArray());
            }

            var reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    yield return MapRowToObject<T>(reader);
                }
            }
            finally
            {
                reader.Dispose();
                command.Dispose();
            }
        }
        
        public async Task<IList<T>> QueryAsync<T>(string sql, Dictionary<string, object> parameters = null) where T : new()
        {
            var list = new List<T>();

            var command = new SqliteCommand(sql, _connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)).ToArray());
            }

            var reader = await command.ExecuteReaderAsync();

            try
            {
                while (await reader.ReadAsync())
                {
                    list.Add(MapRowToObject<T>(reader));
                }

                return list;
            }
            finally
            {
                reader.Dispose();
                command.Dispose();
            }
        }



        // Método para executar uma query e retornar o primeiro objeto tipado
        public T QueryFirst<T>(string sql, Dictionary<string, object> parameters = null) where T : new()
        {
            using (var command = new SqliteCommand(sql, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)));


                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapRowToObject<T>(reader);
                    }
                }
            }

            return default; // Retorna null para tipos de referência ou valor padrão para tipos de valor
        }
        
        // Método para executar uma query e retornar o primeiro objeto tipado
        public async Task<T> QueryFirstAsync<T>(string sql, Dictionary<string, object> parameters = null) where T : new()
        {
            using (var command = new SqliteCommand(sql, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)));


                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapRowToObject<T>(reader);
                    }
                }
            }

            return default; // Retorna null para tipos de referência ou valor padrão para tipos de valor
        }


        // Método para executar uma ação que não retorna nada (INSERT, UPDATE, DELETE, etc.)
        public void Execute(string sql, Dictionary<string, object> parameters = null)
        {
            using (var command = new SqliteCommand(sql, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)));

                command.ExecuteNonQuery();
            }
        }
        
        // Método para executar uma ação que não retorna nada (INSERT, UPDATE, DELETE, etc.)
        public async Task ExecuteAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (var command = new SqliteCommand(sql, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)));

                await command.ExecuteNonQueryAsync();
            }
        }


        public object? ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {
            using (var command = new SqliteCommand(sql, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)));

                return command.ExecuteScalar();
            }
        }
        
        public async Task<object?> ExecuteScalarAsync(string sql, Dictionary<string, object> parameters = null)
        {
            using (var command = new SqliteCommand(sql, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters.Select(x => new SqliteParameter($"@{x.Key}", x.Value)));

                return command.ExecuteScalarAsync();
            }
        }


        // Método para mapear uma linha do resultado para um objeto tipado
        T MapRowToObject<T>(SqliteDataReader reader) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (reader.HasColumn(property.Name) && !reader.IsDBNull(property.Name))
                {
                    var value = reader[property.Name];
                    if (value.GetType() != typeof(DBNull))
                    {
                        property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }

            return obj;
        }

        // Implementação da interface IDisposable
        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }

    // Extensão para verificar se uma coluna existe no SqliteDataReader
    public static class SqliteDataReaderExtensions
    {
        public static bool HasColumn(this SqliteDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
