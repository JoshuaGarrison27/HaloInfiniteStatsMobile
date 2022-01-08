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
    public PlayerMatches _playerMatches;
    public PlayerMatchesViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService,
        IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    {}

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
            var requestObject = new PlayerMatchListRequest(gamertag, 25, 0, "matchmade");
            PlayerMatches = await _haloInfiniteService.GetPlayerMatches(requestObject).ConfigureAwait(false);
        }
    }

    private void OnMatchTapped(Match match)
    {
        _navigationService.NavigateToAsync<MatchDetailsViewModel>(match);
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
