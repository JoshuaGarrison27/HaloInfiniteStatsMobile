using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.ViewModels;

public class ServiceRecordViewModel : ViewModelBase
{
    private string _gamertag;
    private MultiplayerServiceRecord _rankedSR;
    private MultiplayerServiceRecord _socialSR;

    public ServiceRecordViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService, IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    {
    }

    public async override Task Initialize(object data)
    {
        await base.Initialize(data);
        Gamertag = data is not string gamertag ? _settingsService.GetItem(SettingsConstants.Gamertag) : gamertag;
        LoadAsyncData();
    }

    private async void LoadAsyncData()
    {
        IsBusy = true;
        var socialServiceRecordRequestObject = new MultiplayerServiceRecordRequest
        {
            Gamertag = Gamertag,
            Filter = MultiplayerFilterConstants.Matchmade_Social
        };
        var rankedServiceRecordRequestObject = new MultiplayerServiceRecordRequest
        {
            Gamertag = Gamertag,
            Filter = MultiplayerFilterConstants.Matchmade_Ranked
        };

        SocialSR = await _haloInfiniteService.GetMultiplayerServiceRecord(socialServiceRecordRequestObject).ConfigureAwait(false);
        RankedSR = await _haloInfiniteService.GetMultiplayerServiceRecord(rankedServiceRecordRequestObject).ConfigureAwait(false);
        IsBusy = false;
    }

    public MultiplayerServiceRecord RankedSR
    {
        get => _rankedSR;
        set
        {
            _rankedSR = value;
            OnPropertyChanged();
        }
    }

    public MultiplayerServiceRecord SocialSR
    {
        get => _socialSR;
        set
        {
            _socialSR = value;
            OnPropertyChanged();
        }
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
}
