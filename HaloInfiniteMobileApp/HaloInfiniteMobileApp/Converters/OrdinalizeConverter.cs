using Humanizer;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Converters;

public class OrdinalizeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(int.TryParse(value.ToString(), out int valueNumber))
        {
            return valueNumber.Ordinalize();
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
