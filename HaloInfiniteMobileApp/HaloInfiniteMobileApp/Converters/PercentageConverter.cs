using System;
using System.Globalization;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Converters
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var roundNumber = 2;

            if (parameter != null)
            {
                if (int.TryParse(parameter.ToString(), out int parsedRoundNumber))
                {
                    roundNumber = parsedRoundNumber;
                }
            }

            if (value.GetType() == typeof(decimal) || value.GetType() == typeof(double) || value.GetType() == typeof(Single))
            {
                var decimalValue = System.Convert.ToDouble(value);
                var roundingNumber = roundNumber;
                return string.Concat(Math.Round(decimalValue, roundingNumber), "%");
            }

            return string.Concat(value, "%");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}