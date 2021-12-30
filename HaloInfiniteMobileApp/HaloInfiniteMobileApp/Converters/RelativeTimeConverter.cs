using Humanizer;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Converters;
public class RelativeTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(DateTime.TryParse(value.ToString(), out DateTime parsedDateTime))
        {
            var now = DateTime.UtcNow;
            var span = now - parsedDateTime;
            return string.Concat(span.Humanize(), " ago");
        }
        else
        {
            return value;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
