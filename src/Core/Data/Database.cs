using FluxoDeCaixa.Mobile.Core.Domain.Entities;
using SQLite;

namespace FluxoDeCaixa.Mobile.Core.Data; 

public class Database : IDisposable
{
    public SQLiteConnection SQLConnection { get; set; }

    public Database(string ConnectionString)
    {
        SQLConnection = new SQLiteConnection(ConnectionString);
    }

    public void Dispose()
    {
        
    }
}
