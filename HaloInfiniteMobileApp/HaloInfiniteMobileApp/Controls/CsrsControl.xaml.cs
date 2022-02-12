using HaloInfiniteMobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CsrsControl : Frame
    {
        public static readonly BindableProperty CsrsRecordProperty = BindableProperty.Create(nameof(CsrsRecord), typeof(CsrRecord),
            typeof(CsrsControl), defaultBindingMode: BindingMode.OneWay, propertyChanged: CsrsRecordPropertyChanged);

        public CsrsControl()
        {
            InitializeComponent();
        }

        public CsrRecord CsrsRecord
        {
            get => (CsrRecord)GetValue(CsrsRecordProperty);
            set => SetValue(CsrsRecordProperty, value);
        }

        private static void CsrsRecordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CsrsControl)bindable;

            if (newValue is CsrRecord record)
            {
                if (record.MeasurementMatchesRemaining > 0)
                {
                    control.TierImage.Source = record?.TierImageUrl;
                    control.TierName.Text = $"{record.MeasurementMatchesRemaining} Matches Until Ranked";
                    control.TierValue.Text = record.Value.ToString();
                }
                else
                {
                    control.TierImage.Source = record?.TierImageUrl;
                    control.TierName.Text = $"{record.Tier} {record.SubTier}";
                    control.TierValue.Text = record.Value.ToString();
                }
            }
        }
    }
}