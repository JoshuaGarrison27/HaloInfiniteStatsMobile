using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HaloInfiniteMobileApp.Extensions;
using System.Linq;
using Xamarin.Forms;
using System;

namespace HaloInfiniteMobileApp.ViewModels;

[QueryProperty(nameof(MatchId), nameof(MatchId))]
public class MatchDetailsViewModel : ViewModelBase
{
    private string _matchId;
    private MatchData _matchDetails;
    private ObservableCollection<Medal> _playerMedals;
    private ObservableCollection<Detail> _teamsDetails;
    private ObservableCollection<Player> _players;
    private Player _myPlayer;
    private bool _showCsr = true;

    public MatchDetailsViewModel()
    {
        Title = "Match Details";
    }

    public override Task Initialize(object data)
    {
        base.Initialize(data);
        if (!string.IsNullOrWhiteSpace(MatchId))
        {
            GetMatchDetails(MatchId);
        }
        return Task.CompletedTask;
    }

    public async void GetMatchDetails(string matchId)
    {
        try
        {
            IsBusy = true;
            var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
            var matchDetailsRequest = new MatchDataRequest() { Id = matchId };
            MatchDetails = await _haloInfiniteService.GetMatchDetails(matchDetailsRequest).ConfigureAwait(false);
            var isTeamGame = MatchDetails.Match.Teams.Enabled;
            var playlistName = MatchDetails.Match.Details.Playlist.Name;

            if (isTeamGame)
            {
                Players = MatchDetails.Match.Players.OrderBy(o => o.Rank).ToObservableCollection();
                Teams = MatchDetails.Match.Teams.details.OrderBy(o => o.Rank).ToObservableCollection();
            }
            else
            {
                Players = MatchDetails.Match.Players.OrderBy(o => o.Rank).ToObservableCollection();
            }

            MyPlayer = Players.FirstOrDefault(o => string.Equals(gamertag, o.Gamertag, StringComparison.OrdinalIgnoreCase));
            ShowCsr = MyPlayer?.Progression != null;

            GetPlayersMedals(gamertag);

            IsBusy = false;
        } catch (Exception ex)
        {
            var d = ex;
        }
    }

    public void GetPlayersMedals(string playerGamertag)
    {
        foreach (var player in Players)
        {
            if (player.Gamertag.Equals(playerGamertag, System.StringComparison.OrdinalIgnoreCase))
            {
                PlayerMedals = player.Stats?.Core?.Breakdowns?.Medals?.ToObservableCollection();
            }
        }
    }

    public string MatchId
    {
        get => _matchId;
        set
        {
            _matchId = value;
            OnPropertyChanged();
        }
    }

    public MatchData MatchDetails
    {
        get => _matchDetails;
        set
        {
            _matchDetails = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Medal> PlayerMedals
    {
        get => _playerMedals;
        set
        {
            _playerMedals = value;
            OnPropertyChanged();
        }
    }

    public Player MyPlayer
    {
        get => _myPlayer;
        set
        {
            _myPlayer = value;
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

    public ObservableCollection<Player> Players
    {
        get => _players;
        set
        {
            _players = value;
            OnPropertyChanged();
        }
    }

    public bool ShowCsr
    {
        get => _showCsr;
        set
        {
            _showCsr = value;
            OnPropertyChanged();
        }
    }
}
