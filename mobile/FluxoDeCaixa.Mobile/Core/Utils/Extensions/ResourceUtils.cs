using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Utils.Extensions;

public class ResourceUtils
{
    public static object GetResourceValue(string key)
    {
        Application.Current!.Resources.TryGetValue(key, out var result);
        return result;
    }

    public static void SetResourceValue(string key, object value)
    {
        Application.Current!.Resources[key] = value;
    }

    public static string GetHexValue(string key)
    {
        Application.Current!.Resources.TryGetValue(key, out var result);
        var color = (Color) result;

        return color.ToHex();
    }
}
