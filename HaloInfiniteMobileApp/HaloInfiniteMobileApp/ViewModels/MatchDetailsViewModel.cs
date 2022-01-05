﻿using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HaloInfiniteMobileApp.Extensions;
using HaloInfiniteMobileApp.Models.MatchData;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;
public class MatchDetailsViewModel : ViewModelBase
{
    private MatchDetails _matchDetails;
    private ObservableCollection<Medal1> _playerMedals;
    private ObservableCollection<Detail> _teamsDetails;
    private ObservableCollection<Models.MatchData.Player> _players;

    public MatchDetailsViewModel(IConnectionService connectionService,
        INavigationService navigationService, IDialogService dialogService, IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    {}

    public ICommand PlayerTapCommand => new Command((gamertag) => NavigateToSR(gamertag));

    private void NavigateToSR(object gamertag)
    {
        _navigationService.NavigateToAsync<ServiceRecordViewModel>(gamertag);
    }

    public override Task Initialize(object data)
    {
        base.Initialize(data);
        Match matchObject = (Match)data;
        GetMatchDetails(matchObject.id);
        return Task.CompletedTask;
    }

    public async void GetMatchDetails(string matchId)
    {
        IsBusy = true;
        var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
        MatchDetails = await _haloInfiniteService.GetMatchDetails(matchId).ConfigureAwait(false);
        var isTeamGame = MatchDetails.data.teams.enabled;
        var playlistName = MatchDetails.data.details.playlist.name;

        if (isTeamGame)
        {
            Players = MatchDetails.data.players.OrderBy(o => o.rank).ToObservableCollection();
            Teams = MatchDetails.data.teams.details.OrderBy(o => o.rank).ToObservableCollection();
        } else
        {
            Players = MatchDetails.data.players.OrderBy(o => o.rank).ToObservableCollection();
        }

        GetPlayersMedals(gamertag);

        IsBusy = false;
    }

    public void GetPlayersMedals(string playerGamertag)
    {
        foreach (var player in Players)
        {
            if (player.gamertag.Equals(playerGamertag, System.StringComparison.OrdinalIgnoreCase))
            {
                PlayerMedals = player.stats?.core?.breakdowns?.medals?.ToObservableCollection();
            }
        }
    }

    public MatchDetails MatchDetails
    {
        get => _matchDetails;
        set
        {
            _matchDetails = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Medal1> PlayerMedals
    {
        get => _playerMedals;
        set
        {
            _playerMedals = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Detail> Teams
    {
        get => _teamsDetails;
        set
        {
            _teamsDetails = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Models.MatchData.Player> Players
    {
        get => _players;
        set
        {
            _players = value;
            OnPropertyChanged();
        }
    }
}
