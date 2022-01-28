using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHeaderTemplate : Grid
    {
        private IHaloInfiniteService _haloInfiniteService;
        private ISettingsService _settingsService;
        private PlayerAppearance _playerAppearance;
        private string _heroText;

        public FlyoutHeaderTemplate()
        {
            InitializeComponent();
            BindingContext = this;

            _haloInfiniteService = DependencyService.Get<IHaloInfiniteService>();
            _settingsService = DependencyService.Get<ISettingsService>();

            _ = SetHeaderContent();

            MessagingCenter.Subscribe<object>(this, MessagingCenterConstants.PlayerUpdated, async (_) =>
            {
                await SetHeaderContent();
            });
        }

        private async Task SetHeaderContent()
        {
            var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
            if (!string.IsNullOrWhiteSpace(gamertag))
            {
                HeroText = gamertag;
                var playerAppearanceRequest = new PlayerAppearanceRequest() { Gamertag = gamertag };
                PlayerAppearance = await _haloInfiniteService.GetPlayerAppearance(playerAppearanceRequest).ConfigureAwait(false);
            }
            else
            {
                HeroText = "Unknown";
                PlayerAppearance = new PlayerAppearance();
            }
        }

        public string HeroText
        {
            get => _heroText;
            set
            {
                _heroText = value;
                OnPropertyChanged();
            }
        }

        public PlayerAppearance PlayerAppearance
        {
            get => _playerAppearance;
            set
            {
                _playerAppearance = value;
                OnPropertyChanged();
            }
        }
    }
}