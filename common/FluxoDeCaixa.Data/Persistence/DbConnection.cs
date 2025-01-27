using FluxoDeCaixa.Domain.Entities;
using Microsoft.VisualBasic;
using SQLite;

namespace FluxoDeCaixa.Data;

public class DbConnection
{
    private SQLiteAsyncConnection? _database;
    private readonly SQLiteDatabaseConfiguration _configuration;

    public DbConnection(SQLiteDatabaseConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public SQLiteAsyncConnection Database
    {
        get
        {
            if (_database is null)
            {
                throw new NullReferenceException("Database connection is null. Need to call Init() before using DbConnection");
            }

            return _database;
        }
    }

    public async Task Init()
    {
        if (_database is not null)
        {
            return;
        }

        _database = new SQLiteAsyncConnection(GetDatabasePath(Constants.DatabaseFilename), Constants.Flags);
        await CreateTables();
    }

    private async Task CreateTables()
    {
        if (_database is null)
        {
            throw new NullReferenceException("Local DB connection is not initialized");
        }

        _ = await _database.CreateTableAsync<Categoria>();
        _ = await _database.CreateTableAsync<Transacao>();
    }

    private string GetDatabasePath(string filename)
    {
        return Path.Combine(_configuration.AppDirectoryPath, filename);
    }
}

internal class Constants
{
    public const string DatabaseFilename = "database.db3";
    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;
}

