using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

public class PlayerMatchesViewModel : ViewModelBase
{
    private PlayerMatches _playerMatches;
    private bool _showLoadMoreMatchesButton = true;

    public PlayerMatchesViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService,
        IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    { }

    public ICommand MatchSelectedCommand => new Command<Match>(OnMatchTapped);
    public ICommand LoadMoreCommand => new Command(LoadMoreMatches);

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
    private async void LoadMoreMatches()
    {
        var matchListCount = _playerMatches.count;
        var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);

        CheckInternetConnection();

        try
        {
            if (_connectionService.IsConnected)
            {
                IsBusy = true;
                var requestObject = new PlayerMatchListRequest(gamertag, 25, matchListCount, "matchmade");
                var nextResultSet = await _haloInfiniteService.GetPlayerMatches(requestObject).ConfigureAwait(false);

                if(nextResultSet != null && nextResultSet?.Matches?.Length > 0)
                {
                    var mergedList = PlayerMatches.Matches.Concat(nextResultSet.Matches);
                    PlayerMatches.Matches = mergedList.ToArray();
                    OnPropertyChanged(nameof(PlayerMatches));
                }
                else
                {
                    _dialogService.ShowToast("No new matches found");
                }
                IsBusy = false;
            }
        }
        catch (Exception ex)
        {
            _dialogService.ShowToast("An error occured. Please Try Again");
        }
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

    public bool ShowLoadMoreMatches
    {
        get => _showLoadMoreMatchesButton;
        set
        {
            _showLoadMoreMatchesButton = value;
            OnPropertyChanged();
        }
    }
}
