using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data;
public class Util
{
    public static IEnumerable<Type> GetTypes(Type __type = null)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(t => t.GetTypes())
            .Where(type => !type.IsAbstract && !type.IsEnum);

        if ( __type != null )
            return types.Where(type => __type.IsAssignableFrom(type));

        return types;
    }
}
