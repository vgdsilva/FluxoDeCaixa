using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public class PropertyUtils
{

    private static Dictionary<Type, PropertyInfo[]> PropertiesDictionary = new Dictionary<Type, PropertyInfo[]>();
    private static Dictionary<Type, PropertyInfo> PropertyKeyAttributeDictionary = new Dictionary<Type, PropertyInfo>();


    public static PropertyInfo[] GetProperties(Type type)
    {
        if ( !PropertiesDictionary.TryGetValue(type, out PropertyInfo[] pi) )
        {
            pi = type.GetProperties();
            PropertiesDictionary.Add(type, pi);
        }

        return pi;
    }

    public static PropertyInfo GetPropertyID(Type type)
    {
        if ( !PropertyKeyAttributeDictionary.TryGetValue(type, out var pi) )
        {
            pi = GetProperties(type).FirstOrDefault(x => x.GetCustomAttribute<KeyAttribute>() != null)
                ?? GetProperties(type).FirstOrDefault(x => x.Name.ToUpper() == $"ID{type.Name.ToUpper()}");
            if ( pi == null )
                throw new Exception($"Tabela {type.Name} com o campo de ID fora do padrão");
        }

        return pi;
    }

}
