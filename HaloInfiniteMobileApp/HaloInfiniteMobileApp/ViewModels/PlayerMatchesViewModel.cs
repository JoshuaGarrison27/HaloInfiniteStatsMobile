using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

public class PlayerMatchesViewModel : ViewModelBase
{
    private readonly ISettingsService _settingsService;
    public PlayerMatches _playerMatches;
    public PlayerMatchesViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService,
        IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService)
    {
        _settingsService = settingsService;
    }

    public ICommand MatchSelectedCommand => new Command<Match>(OnMatchTapped);

    public async override Task Initialize(object data)
    {
        IsBusy = true;
        _ = base.Initialize(data);
        await RefreshMatches().ConfigureAwait(false);
        IsBusy = false;
    }

    public async Task RefreshMatches()
    {
        var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);

        if (gamertag != null)
        {
            PlayerMatches = await _haloInfiniteService.GetPlayerMatches(gamertag);
        }
    }

    private async void OnMatchTapped(Match match)
    {
        await _dialogService.ShowDialog(match.id, "Match Selected", "OK");
    }

    public PlayerMatches PlayerMatches
    {
        get => _playerMatches;
        set
        {
            _playerMatches = value;
            OnPropertyChanged();
        }
    }
}
