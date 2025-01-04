using System.Globalization;

namespace FluxoDeCaixa.MAUI.Utils.Converters;

public class TemplateConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string templateKey && Application.Current!.Resources.TryGetValue(templateKey, out var template))
        {
            return template;
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
