using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Data;

public class AppContext
{

    static AppContext _instance;

    public static AppContext Instance 
    { 
        get 
        { 
            return _instance ?? new AppContext(); 
        } 
    }


    public bool IsValidContext()
    {



        return true;
    }
}
