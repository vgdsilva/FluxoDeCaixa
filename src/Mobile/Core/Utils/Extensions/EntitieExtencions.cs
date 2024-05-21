using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa;
public static class EntitieExtencions
{
    public static string GenerateUniqueIdentifier(this string str) => Guid.NewGuid().ToString();

    public static string GetNewUniqueIdentifier(this string str) => "00000000-0000-0000-0000-080000000000";


}
