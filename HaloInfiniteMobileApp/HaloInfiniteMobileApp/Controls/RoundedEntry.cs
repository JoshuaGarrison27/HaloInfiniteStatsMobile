using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Controls
{
    public class RoundedEntry : Entry
    {
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor),
                typeof(Color), typeof(RoundedEntry), Color.Gray);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(int),
                typeof(RoundedEntry), BorderWidthDevicePlatform());

        private static int BorderWidthDevicePlatform()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return 1;
                default:
                    return 2;
            }
        }

        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius),
                typeof(double), typeof(RoundedEntry), CornerRadiusDevicePlatform());

        private static double CornerRadiusDevicePlatform()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return 6;
                default:
                    return 7;
            }
        }

        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
            BindableProperty.Create(nameof(IsCurvedCornersEnabled),
                typeof(bool), typeof(RoundedEntry), true);

        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
    }
}