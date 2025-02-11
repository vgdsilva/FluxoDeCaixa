using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data.Context;

public class SQLiteContext : DbContext
{
    public string DatabasePath { get; set; }

    public SQLiteContext(string databasePath)
    {
        DatabasePath = databasePath;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite(DatabasePath);
    }
}
