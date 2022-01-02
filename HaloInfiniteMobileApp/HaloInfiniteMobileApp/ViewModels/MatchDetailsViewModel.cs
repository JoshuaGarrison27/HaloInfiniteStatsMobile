using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HaloInfiniteMobileApp.Extensions;
using HaloInfiniteMobileApp.Models.MatchData;
using System.Linq;

namespace HaloInfiniteMobileApp.ViewModels;
public class MatchDetailsViewModel : ViewModelBase
{
    private MatchDetails _matchDetails;
    private ObservableCollection<Medal1> _playerMedals;
    private ObservableCollection<Detail> _teamsDetails;
    

    public MatchDetailsViewModel(IConnectionService connectionService,
        INavigationService navigationService, IDialogService dialogService, IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    {}

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
        var players = MatchDetails.data.players;
        var playlistName = MatchDetails.data.details.playlist.name;
        Teams = MatchDetails.data.teams.details.OrderBy(o => o.rank).ToObservableCollection();
                
        foreach (var player in players)
        {
            if (player.gamertag.Equals(gamertag, System.StringComparison.OrdinalIgnoreCase))
            {
                PlayerMedals = player.stats?.core?.breakdowns?.medals?.ToObservableCollection();
            }
        }
        IsBusy = false;

        if (playlistName == "FFA Slayer")
        {
            await _dialogService.ShowDialog("This is an FFA Slayer Match Not a Team Event", "Playlist Warning!", "OK");
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
}
