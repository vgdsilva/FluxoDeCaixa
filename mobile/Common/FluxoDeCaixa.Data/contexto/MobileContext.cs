using FluxoDeCaixa.Data.Geral;
using System.Globalization;

namespace FluxoDeCaixa.Data.Contexto;

public class MobileContext
{
    public static MobileContext Instance { get; private set; }
    public string ConnectionString { get; set; }
    public CultureInfo Culture { get; set; }  


    public static void AssignNewInstance(string connectionString, CultureInfo culture)
    {
        Instance = new MobileContext()
        {
            ConnectionString = connectionString,
            Culture = culture
        };
    }

    public SQLQuery AssignNewInstanceSQLQuery() =>
        new SQLQuery(ConnectionString);
}
