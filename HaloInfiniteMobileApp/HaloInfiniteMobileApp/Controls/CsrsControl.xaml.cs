using HaloInfiniteMobileApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CsrsControl : Frame
    {
        public static readonly BindableProperty CompetitiveSkillRankDataProperty = BindableProperty.Create(nameof(CompetitiveSkillRankData), typeof(CompetitiveSkillRankData),
            typeof(CsrsControl), defaultBindingMode: BindingMode.OneWay, propertyChanged: CompetitiveSkillRankDataPropertyChanged);

        public static readonly BindableProperty QueueNameProperty = BindableProperty.Create(nameof(QueueName), typeof(string),
            typeof(CsrsControl), defaultBindingMode: BindingMode.OneWay, propertyChanged: CompetitiveSkillRankDataPropertyChanged);

        public static readonly BindableProperty InputNameProperty = BindableProperty.Create(nameof(InputName), typeof(string),
            typeof(CsrsControl), defaultBindingMode: BindingMode.OneWay, propertyChanged: CompetitiveSkillRankDataPropertyChanged);

        public static readonly BindableProperty RangeNameProperty = BindableProperty.Create(nameof(RangeName), typeof(string),
            typeof(CsrsControl), defaultBindingMode: BindingMode.OneWay, propertyChanged: CompetitiveSkillRankDataPropertyChanged);

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string),
            typeof(CsrsControl), defaultBindingMode: BindingMode.OneWay, propertyChanged: TitleTextPropertyChanged);

        public CsrsControl()
        {
            InitializeComponent();
        }

        public CompetitiveSkillRankData CompetitiveSkillRankData
        {
            get => (CompetitiveSkillRankData)GetValue(CompetitiveSkillRankDataProperty);
            set => SetValue(CompetitiveSkillRankDataProperty, value);
        }

        public string QueueName
        {
            get => (string)GetValue(QueueNameProperty);
            set => SetValue(QueueNameProperty, value);
        }

        public string InputName
        {
            get => (string)GetValue(InputNameProperty);
            set => SetValue(InputNameProperty, value);
        }

        public string RangeName
        {
            get => (string)GetValue(RangeNameProperty);
            set => SetValue(RangeNameProperty, value);
        }

        public string TitleText
        {
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }

        private static void CompetitiveSkillRankDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CsrsControl)bindable;
            control.CardTitleText.Text = control.TitleText;
            var queueName = control.QueueName ?? "open";
            var inputName = control.InputName ?? "crossplay";

            if (newValue is not CompetitiveSkillRankData data)
                return;

            var record = Array.Find(data.Data, o => o.Queue.Equals(queueName, StringComparison.OrdinalIgnoreCase) && o.Input.Equals(inputName, StringComparison.OrdinalIgnoreCase));

            CsrRecord csrsRecord = control.RangeName switch
            {
                "current" => record.CsrGroups.Current,
                "season" => record.CsrGroups.Season,
                _ => record.CsrGroups.AllTime,
            };

            if (csrsRecord.MeasurementMatchesRemaining > 0)
            {
                control.TierImage.Source = csrsRecord?.TierImageUrl;
                control.TierName.Text = $"{csrsRecord.MeasurementMatchesRemaining} Matches Until Ranked";
                control.TierValue.Text = csrsRecord.Value.ToString();
            }
            else
            {
                control.TierImage.Source = csrsRecord?.TierImageUrl;
                control.TierName.Text = $"{csrsRecord.Tier} {csrsRecord.SubTier}";
                control.TierValue.Text = csrsRecord.Value.ToString();
            }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CsrsControl)bindable;
            control.CardTitleText.Text = newValue?.ToString();
        }
    }
}