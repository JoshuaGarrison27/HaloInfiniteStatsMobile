using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using HaloInfiniteMobileApp.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private string _gamertag;
        private string _emblemUrl;
        public ICommand GoToGithubCommand => new AsyncCommand(GoToGithub);

        public override async Task Initialize(object data)
        {
            await base.Initialize(data).ConfigureAwait(false);

            var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
            if (string.IsNullOrWhiteSpace(gamertag))
            {
                await Shell.Current.GoToAsync(nameof(OnboardingPage));
            }
            else
            {
                Gamertag = gamertag;
                Title = $"Welcome {gamertag}";
                await GetPlayerAppearance().ConfigureAwait(false);
                await GetCsrsRecord().ConfigureAwait(false);
            }
        }

        private async Task GetPlayerAppearance()
        {
            if (string.IsNullOrWhiteSpace(_gamertag))
            {
                return;
            }

            var haloInfiniteService = DependencyService.Get<IHaloInfiniteService>();
            var playerAppearanceRequest = new PlayerAppearanceRequest() { Gamertag = Gamertag };
            var playerAppearance = await haloInfiniteService.GetPlayerAppearance(playerAppearanceRequest).ConfigureAwait(false);

            if (playerAppearance != null)
            {
                EmblemUrl = playerAppearance.PlayerIdentity.EmblemUrl;
            }
        }

        private async Task GetCsrsRecord()
        {
            var csrsRequest = new PlayerCsrsRequest(Gamertag);
            CsrsData = await _haloInfiniteService.GetPlayerCsrs(csrsRequest);
        }

        private async Task GoToGithub()
        {
            await Browser.OpenAsync(GeneralConstants.GithubLinkIssues);
        }

        private CompetitiveSkillRankData _csrsData;
        public CompetitiveSkillRankData CsrsData
        {
            get => _csrsData;
            set
            {
                _csrsData = value;
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

        public string EmblemUrl
        {
            get => _emblemUrl;
            set
            {
                _emblemUrl = value;
                OnPropertyChanged();
            }
        }
    }
}