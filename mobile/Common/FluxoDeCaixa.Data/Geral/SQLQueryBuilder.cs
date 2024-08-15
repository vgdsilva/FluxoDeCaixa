using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace FluxoDeCaixa.Data.Geral;

public abstract class QueryBuilder
{

    public static QueryBuilder Select() =>
        new SQLQueryBuilder();

    public static SQLTableBuilder CreateTable(string tableName) =>
        new SQLTableBuilder(tableName);

    public static SQLInsertBuilder InsertInto(string tableName) =>
        new SQLInsertBuilder(tableName);

    public static SQLUpdateBuilder Update(string tableName) =>
        new SQLUpdateBuilder(tableName);
    

    public abstract string GenerateSQL();
}

public class SQLQueryBuilder : QueryBuilder
{
    public override string GenerateSQL()
    {
        throw new NotImplementedException();
    }
}

public class SQLTableBuilder : QueryBuilder
{
    string tableName { get; set; }
    List<string> columns { get; set; }
    string PK { get; set; }
    List<string> FKs { get; set; }


    public SQLTableBuilder(string tableName)
    {
        this.tableName = tableName;
        PK = string.Empty;
        columns = new List<string>();
        FKs = new List<string>();
    }

    public SQLTableBuilder AddPrimaryKey(string primaryKeyName, string primaryKeyType)
    {
        columns.Add(CreateSQLColumn(primaryKeyName, primaryKeyType));
        PK = primaryKeyName;

        return this;
    }

    public SQLTableBuilder AddColumn(string columnName, string columnType)
    {
        columns.Add(CreateSQLColumn(columnName, columnType));
        return this;
    }

    string CreateSQLColumn(string columnName, string columnType)
    {
        return $@"{columnName} {columnType}";
    }



    public SQLTableBuilder AddForeignKey(string columnName, string referencedTable, string referencedColumn)
    {
        FKs.Add(CreateSQLFK(columnName, referencedTable, referencedColumn));
        return this;
    }

    string CreateSQLFK(string columnName, string referencedTable, string referencedColumn)
    {
        return $@"FOREIGN KEY ({columnName}) REFERENCES {referencedTable}({referencedColumn})";
    }

    public override string GenerateSQL()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($@"CREATE TABLE {tableName}");
        builder.AppendLine(  "(");

        foreach (var column in columns)
            builder.AppendLine($@"  {column},");

        builder.AppendLine($@"  PRIMARY KEY({PK})");

        if (FKs.Count > 0)
        {
            builder.Append(",");

            int countFKs = 0;
            foreach (var FK in FKs)
            {
                countFKs++;
                if (countFKs > 1)
                    builder.Append(",");

                builder.AppendLine($@"  {FK}");
            }
        }

        builder.AppendLine(  ");");

        return builder.ToString();
    }
}

public class SQLInsertBuilder : QueryBuilder
{

    string TableName { get; set; }

    Dictionary<string, object> ColumnValues { get; set; }


    public SQLInsertBuilder(string tableName)
    {
        TableName = tableName;
        ColumnValues = new Dictionary<string, object>();
    }

    public SQLInsertBuilder AddField(string columnName, object columnValue)
    {
        ColumnValues.Add(columnName, columnValue);

        return this;
    }

    public override string GenerateSQL()
    {
        StringBuilder builder = new StringBuilder();

        List<string> columns = new List<string>();
        List<object> values = new List<object>(); ;

        foreach (var ColumnAndValue in ColumnValues)
        {
            columns.Add(ColumnAndValue.Key);
            values.Add(ColumnAndValue.Value);
        }

        builder.AppendLine($@"INSERT INTO {TableName} ({string.Join(",", columns)})");
        builder.AppendLine($@"                 VALUES ({string.Join(",", values)})");

        return builder.ToString();
    }
}

public class SQLUpdateBuilder : QueryBuilder
{
    string TableName { get; set; }

    Dictionary<string, object> FieldsToSet { get; set; }
    Dictionary<string, object> Wheres { get; set; }


    public SQLUpdateBuilder(string tableName)
    {
        TableName = tableName;

        FieldsToSet = new Dictionary<string, object>();
        Wheres = new Dictionary<string, object>();
    }

    public SQLUpdateBuilder SetField(string columnName, object columnValue)
    {
        FieldsToSet.Add(columnName, columnValue);
        return this;
    }

    public SQLUpdateBuilder Where(string columnName, object columnValue)
    {
        Wheres.Add(columnName, columnValue);
        return this;
    }

    public override string GenerateSQL()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($@"UPDATE {TableName} SET {string.Join(", ", FieldsToSet.Select(x => string.Format("{0} = {1}", x.Key, x.Value)) )} ");

        //if (Wheres.Count == 0)
        //    throw new Exception("Update without WHERE clause");

        if (Wheres.Count > 0)
        {
            builder.AppendLine("WHERE");

            int countWheres = 0;
            foreach (var where in Wheres)
            {
                countWheres++;
                builder.AppendLine($@"  {(countWheres > 1 ? "AND " : string.Empty)}{where.Key} = {where.Value}");
            }
        }


        return builder.ToString();
    }
}
