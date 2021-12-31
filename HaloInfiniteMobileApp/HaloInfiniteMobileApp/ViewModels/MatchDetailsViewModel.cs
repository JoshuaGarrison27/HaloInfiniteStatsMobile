using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HaloInfiniteMobileApp.Extensions;
using HaloInfiniteMobileApp.Models.MatchData;

namespace HaloInfiniteMobileApp.ViewModels;
public class MatchDetailsViewModel : ViewModelBase
{
    private MatchDetails _matchDetails;
    private ObservableCollection<Medal1> _playerMedals;

    public MatchDetailsViewModel(IConnectionService connectionService,
        INavigationService navigationService, IDialogService dialogService, IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    { }

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
        foreach (var player in players)
        {
            if (player.gamertag.Equals(gamertag, System.StringComparison.OrdinalIgnoreCase))
            {
                PlayerMedals = player.stats?.core?.breakdowns?.medals?.ToObservableCollection();
            }
        }
        //PlayerMedals = MatchDetails.data.players.FirstOrDefault(o => string.Equals(gamertag, o.gamertag, System.StringComparison.InvariantCultureIgnoreCase))?.stats?.core?.breakdowns?.medals?.ToObservableCollection();
        IsBusy = false;
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
}
