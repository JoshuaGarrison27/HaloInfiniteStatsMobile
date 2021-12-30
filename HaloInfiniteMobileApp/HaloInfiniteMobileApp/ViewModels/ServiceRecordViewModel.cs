using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Threading;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.ViewModels;

public class ServiceRecordViewModel : ViewModelBase
{
    private readonly ISettingsService _settingsService;
    private string _gamertag;
    private MultiplayerServiceRecord _rankedSR;
    private MultiplayerServiceRecord _socialSR;

    public ServiceRecordViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService, IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService)
    {
        _settingsService = settingsService;
        Gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
    }

    public async override Task Initialize(object data)
    {
        await base.Initialize(data);

        LoadAsyncData();
    }

    private async void LoadAsyncData()
    {
        IsBusy = true;
        SocialSR = await _haloInfiniteService.GetMultiplayerServiceRecord(Gamertag, MultiplayerFilterConstants.Matchmade_Social).ConfigureAwait(false);
        RankedSR = await _haloInfiniteService.GetMultiplayerServiceRecord(Gamertag, MultiplayerFilterConstants.Matchmade_Ranked).ConfigureAwait(false);
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
