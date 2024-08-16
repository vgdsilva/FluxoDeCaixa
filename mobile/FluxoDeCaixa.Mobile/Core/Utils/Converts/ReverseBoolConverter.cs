using System.Globalization;

namespace FluxoDeCaixa.Mobile.Core.Utils.Converts;

public class ReverseBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value == null)
            return false;

        return !(bool) value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}
