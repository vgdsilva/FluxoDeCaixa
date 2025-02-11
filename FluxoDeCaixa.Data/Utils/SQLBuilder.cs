using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data.Utils;

public class SQLBuilder
{
    public enum CommandType { NONE, INSERT, UPDATE, DELETE, SELECT, ALTER }

    private CommandType _command = CommandType.NONE;

    private string? _table;
    private List<string> _columns = new();
    private List<string> _values = new();
    private List<string> _setClauses = new();
    private List<string> _whereClauses = new();
    private List<string> _groupByClauses = new();

    public SQLBuilder()
    {

    }

    public SQLBuilder SetCommandType(CommandType command)
    {
        _command = command;
        return this;
    }

    public SQLBuilder From(string tableFrom)
    {
        _table = tableFrom;
        return this;
    }

    public override string ToString()
    {
        StringBuilder sqlBuilder = new();

        switch (_command)
        {
            default:
            case CommandType.NONE: throw new InvalidOperationException("O tipo de comando SQL não foi definido.");
            case CommandType.INSERT: //INSERT INTO nome_da_tabela (coluna1, coluna2, ...) VALUES(valor1, valor2, ...);
                sqlBuilder.Append("INSERT INTO ");
                break;
            case CommandType.UPDATE: // UPDATE nome_da_tabela SET coluna1 = valor1, coluna2 = valor2 WHERE condição;
                sqlBuilder.Append("UPDATE ");
                break;
            case CommandType.DELETE: //DELETE FROM nome_da_tabela WHERE condição;
                sqlBuilder.Append("DELETE ");
                break;
            case CommandType.SELECT: //SELECT coluna1, coluna2 FROM nome_da_tabela WHERE condição;
                sqlBuilder.Append("SELECT ");
                break;
            case CommandType.ALTER:

                break;
        }


        string sql = sqlBuilder.ToString();

        Console.WriteLine(sql);

        return sql;
    }
}


