using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data.contexto;
public class MobileContext
{
    private static MobileContext _Instance;
    public static MobileContext Instance
    {
        get
        {
            if ( _Instance == null )
                _Instance = new MobileContext();
            return _Instance;
        }
    }

    public string databasePath { get; set; }

    public MobileContext()
    {
        
    }

    public MobileContext(string path, string Culture = "pt-BR")
    {
        databasePath = path;

        _Instance = this;
    }
}
