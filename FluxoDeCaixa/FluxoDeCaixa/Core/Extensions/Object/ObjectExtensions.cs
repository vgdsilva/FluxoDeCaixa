using FluxoDeCaixa.Mobile.Core.Extensions.Attributes;
using FluxoDeCaixa.Mobile.Views.Pages;
using System.Reflection;

namespace FluxoDeCaixa;

public static class ObjectExtensions
{
    public static string GetEnumDescription(this Enum value)
    {
        try
        {

            if ( value == null )
                return string.Empty;

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if ( fieldInfo == null ) 
                return null;

            var attributes = (EnumDescription[]) fieldInfo.GetCustomAttributes(typeof(EnumDescription), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        catch ( Exception )
        {
            return string.Empty;
        }
    }

    public static void Teste(this ContentPage Page)
    {

    }
}
