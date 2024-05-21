using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Commun.Utils;
public static class EntityUtils
{
    public static string GenerateUniqueIdentifier()
    {
        return Guid.NewGuid().ToString();
    }
}
