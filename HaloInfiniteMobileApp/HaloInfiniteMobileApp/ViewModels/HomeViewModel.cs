using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using HaloInfiniteMobileApp.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

public class HomeViewModel : ViewModelBase
{
    private string _gamertag;
    private string _emblemUrl;

    public override async Task Initialize(object data)
    {
        await base.Initialize(data).ConfigureAwait(false);

        Gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
        if (string.IsNullOrWhiteSpace(Gamertag))
        {
            await Shell.Current.GoToAsync($"//{nameof(OnboardingView)}");
        } else
        {
            await GetPlayerAppearance().ConfigureAwait(false);
        }
    }

    private async Task GetPlayerAppearance()
    {
        if (string.IsNullOrWhiteSpace(_gamertag))
        {
            return;
        }

        var haloInfiniteService = DependencyService.Get<IHaloInfiniteService>();
        var playerAppearanceRequest = new PlayerAppearanceRequest() { Gamertag = Gamertag };
        var playerAppearance = await haloInfiniteService.GetPlayerAppearance(playerAppearanceRequest).ConfigureAwait(false);

        if (playerAppearance != null)
        {
            EmblemUrl = playerAppearance.PlayerIdentity.EmblemUrl;
        }
    }

    public ICommand ClearCacheCommand => new Command(ClearCache);
    public ICommand SwitchAccountsCommand => new AsyncCommand(SwitchAccounts);

    private void ClearCache()
    {
        _haloInfiniteService.InvalidateCache();
        _dialogService.ShowToast("Halo Cache Cleared");
    }

    private async Task SwitchAccounts()
    {
        _settingsService.RemoveItem(SettingsConstants.Gamertag);
        _haloInfiniteService.InvalidateCache();
        await Shell.Current.GoToAsync($"//{nameof(OnboardingView)}");
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
