using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class OnboardingView : ContentPage
{
    public OnboardingView()
    {
        InitializeComponent();
        BindingContext = DependencyService.Get<OnboardingViewModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var settingsService = DependencyService.Get<ISettingsService>();
        var gamertag = settingsService.GetItem(SettingsConstants.Gamertag);
        if (gamertag != null)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
        }
    }
}
