using HaloInfiniteMobileApp.Views;
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
        }
    }
}