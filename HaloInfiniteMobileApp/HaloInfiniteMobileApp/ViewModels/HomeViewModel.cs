using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IHaloInfiniteService _haloInfiniteService;
        private string _gamertag;
        private string _emblemUrl;

        public HomeViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService, ISettingsService settingsService, IHaloInfiniteService haloInfiniteService) : base(connectionService, navigationService, dialogService)
        {
            _settingsService = settingsService;
            _haloInfiniteService = haloInfiniteService;
            Gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
        }

        public override async Task InitializeAsync(object data)
        {
            base.InitializeAsync(data);

            await GetPlayerAppearance();
        }

        private async Task GetPlayerAppearance()
        {
            if (string.IsNullOrWhiteSpace(_gamertag))
            {
                return;
            }

            var playerAppearance = await _haloInfiniteService.GetPlayerAppearance(Gamertag).ConfigureAwait(false);

            if (playerAppearance != null)
            {
                EmblemUrl = playerAppearance.PlayerIdentity.EmblemUrl;
            }
        }

        public ICommand TestButton => new Command(DoNothing);

        private async void DoNothing()
        {
            await _dialogService.ShowDialog("This button doesnt do anything.", "Button Clicked", "OK");
        }
        public string Gamertag
        {
            get => _gamertag;
            set
            {
                _gamertag = value;
                OnPropertyChanged();
            }
        }

        public string EmblemUrl
        {
            get => _emblemUrl;
            set
            {
                _emblemUrl = value;
                OnPropertyChanged();
            }
        }
    }
}
