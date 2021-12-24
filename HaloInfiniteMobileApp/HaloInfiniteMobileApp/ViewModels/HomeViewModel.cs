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
        private string _gamertag;
        private string _emblemUrl;

        public HomeViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService, ISettingsService settingsService, IHaloInfiniteService haloInfiniteService) : base(connectionService, navigationService, dialogService, haloInfiniteService)
        {
            _settingsService = settingsService;
            Gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
        }

        public override async Task InitializeAsync(object data)
        {
            await base.InitializeAsync(data).ConfigureAwait(false);

            await GetPlayerAppearance().ConfigureAwait(false);
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

        public ICommand ClearCacheCommand => new Command(ClearCache);

        private async void ClearCache()
        {
            _haloInfiniteService.InvalidateHaloCache();
            await _dialogService.ShowDialog("Halo Cache Cleared", "Cache Cleared", "OK");
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
