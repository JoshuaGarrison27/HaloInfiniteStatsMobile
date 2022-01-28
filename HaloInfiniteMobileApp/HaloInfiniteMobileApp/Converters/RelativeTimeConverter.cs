using HaloInfiniteMobileApp.Extensions;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Converters
{
    public class RelativeTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var relativeTime = "Unknown";
            try
            {
                if (value is DateTime valueDateTime)
                {
                    relativeTime = valueDateTime.GetRelativeTime();
                }
            }
            catch (Exception)
            {
                return relativeTime;
            }
            return relativeTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}