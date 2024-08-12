using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Utils.Classes;
public class DataUtils
{
    public static string NewID()
    {
        return Guid.NewGuid().ToString();
    }

    public static string Empty()
    {
        return Guid.Empty.ToString();
    }
}
