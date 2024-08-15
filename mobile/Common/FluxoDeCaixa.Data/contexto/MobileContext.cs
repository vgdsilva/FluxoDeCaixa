using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data.contexto;
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
}
