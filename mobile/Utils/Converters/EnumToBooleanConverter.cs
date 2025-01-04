using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Utils.Converters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            // Converte o valor para o tipo inteiro do enum
            var enumValueAsInt = (int)value;

            // Converte o parâmetro para inteiro e compara com o valor do enum
            if (int.TryParse(parameter.ToString(), out var enumCondition))
            {
                return enumValueAsInt == enumCondition;
            }

            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
