using System;
using System.Globalization;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Converters;

public class PercentageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var paramParse = int.TryParse(parameter.ToString(), out int roundNumber);

        if (value.GetType() == typeof(decimal) || value.GetType() == typeof(double))
        {
            var decimalValue = (decimal)value;
            var roundingNumber = paramParse ? roundNumber : 2;
            return string.Concat(Math.Round(decimalValue, roundingNumber), "%");
        }

        return string.Concat(value, "%");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}