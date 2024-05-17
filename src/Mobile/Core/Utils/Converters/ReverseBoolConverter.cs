using System.Globalization;

namespace FluxoDeCaixa.Core.Utils.Converters;
public class ReverseBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if ( value == null )
            return false;

        return !(bool) value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}
