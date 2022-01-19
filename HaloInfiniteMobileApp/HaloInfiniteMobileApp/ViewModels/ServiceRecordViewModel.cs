using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

[QueryProperty(nameof(Gamertag), nameof(Gamertag))]
public class ServiceRecordViewModel : ViewModelBase
{
    private string _gamertag;
    private MultiplayerServiceRecord _rankedSR;
    private MultiplayerServiceRecord _socialSR;

    public ServiceRecordViewModel()
    {
        Title = "Service Record";
    }

    public async override Task Initialize(object data)
    {
        await base.Initialize(data);
        if(Gamertag == null)
        {
            Gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
        }
        Title = $"{Gamertag} - Service Record";
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
