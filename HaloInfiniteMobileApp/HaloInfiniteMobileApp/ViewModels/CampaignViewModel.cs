using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;
public class CampaignViewModel : ViewModelBase
{
    private Campaign _campaign;
    private string _highestDifficulty;
    public ICommand HelpCommand => new Command(CampaignHelpCommand);
    public ICommand RefreshCommand => new AsyncCommand(() => CampaignRefreshCommand());

    public CampaignViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService,
        IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    { }

    public async override Task Initialize(object data)
    {
        IsBusy = true;
        _ = base.Initialize(data);
        await RefreshCampaignData().ConfigureAwait(false);
        IsBusy = false;
    }

    private async Task RefreshCampaignData(bool ignoreCache = false)
    {
        var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);

        if (gamertag != null)
        {
            var requestObject = new CampaignRequest(gamertag)
            {
                IgnoreCache = ignoreCache
            };
            var campaignRecord = await _haloInfiniteService.GetCampaignRecord(requestObject).ConfigureAwait(false);
            Campaign = campaignRecord.Campaign;

            if (Campaign.Difficulty.HighestCompleted == null)
            {
                HighestDifficulty = $"Mission {Campaign.MissionsCompleted} of {Campaign.Defaults.TotalMissions}";
            }
            else
            {
                HighestDifficulty = Campaign.Difficulty.LasoCompleted ? $"{Campaign.Difficulty.HighestCompleted.ToUpper()} - LASO" : Campaign.Difficulty.HighestCompleted.ToUpper();
            }
        }

        EnsureCampaignDataShared();
    }

    private async Task CampaignRefreshCommand()
    {
        IsBusy = true;
        await RefreshCampaignData(true).ConfigureAwait(false);
        IsBusy = false;
    }

    private void EnsureCampaignDataShared()
    {
        if(Campaign.MissionsCompleted == 0 )
        {
            _dialogService.ShowToast("No Data? Click the help menu option in the corner!");
        }
    }

    private void CampaignHelpCommand()
    {
        _dialogService.ShowDialog("If you have no data showing here, you need to go into Halo Infinite's Settings (In-game) and turn on campaign data sharing.", "No Data?", "Okay");
    }

    public Campaign Campaign
    {
        get => _campaign;
        set
        {
            _campaign = value;
            OnPropertyChanged();
        }
    }
    public string HighestDifficulty
    {
        get => _highestDifficulty;
        set
        {
            _highestDifficulty = value;
            OnPropertyChanged();
        }
    }
}
