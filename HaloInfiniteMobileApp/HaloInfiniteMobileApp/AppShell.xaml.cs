using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(OnboardingPage), typeof(OnboardingPage));
            Routing.RegisterRoute(nameof(MatchDetailsPage), typeof(MatchDetailsPage));

            //TODO Force Dark Theme for now until UI cleaned up
            Application.Current.UserAppTheme = OSAppTheme.Dark;
        }

        public ICommand SwitchAccountCommand => new AsyncCommand(SwitchAccount);

        public async Task SwitchAccount()
        {
            var dialogService = DependencyService.Get<IDialogService>();
            var settingsService = DependencyService.Get<ISettingsService>();
            var userConfirmation = await dialogService.ShowDialogYesNoQuestion("Switch Accounts", "Are you sure you want to switch accounts?", "Lets Go!", "Nevermind");
            if (userConfirmation)
            {
                settingsService.RemoveItem(SettingsConstants.Gamertag);
                await Shell.Current.GoToAsync($"/{nameof(OnboardingPage)}");
            }
        }
    }
}