using HaloInfiniteMobileApp.Views;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(OnboardingView), typeof(OnboardingView));
        Routing.RegisterRoute(nameof(MatchDetailsView), typeof(MatchDetailsView));
    }
}
