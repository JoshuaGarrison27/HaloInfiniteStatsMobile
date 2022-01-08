using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private string _gamertag;
    private string _emblemUrl;

    public HomeViewModel(IConnectionService connectionService,
        INavigationService navigationService,
        IDialogService dialogService, ISettingsService settingsService, IHaloInfiniteService haloInfiniteService) : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    {
        Gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
    }

    public override async Task Initialize(object data)
    {
        await base.Initialize(data).ConfigureAwait(false);

        await GetPlayerAppearance().ConfigureAwait(false);
    }

    private async Task GetPlayerAppearance()
    {
        if (string.IsNullOrWhiteSpace(_gamertag))
        {
            return;
        }

        var playerAppearanceRequest = new PlayerAppearanceRequest() { Gamertag = Gamertag };
        var playerAppearance = await _haloInfiniteService.GetPlayerAppearance(playerAppearanceRequest).ConfigureAwait(false);

        if (playerAppearance != null)
        {
            EmblemUrl = playerAppearance.PlayerIdentity.EmblemUrl;
        }
    }

    public ICommand ClearCacheCommand => new Command(ClearCache);

    private async void ClearCache()
    {
        _haloInfiniteService.InvalidateCache();
        _dialogService.ShowToast("Halo Cache Cleared");
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
