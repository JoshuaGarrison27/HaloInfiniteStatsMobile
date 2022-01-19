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

        if (BindingContext is OnboardingViewModel)
            await ((BindingContext as OnboardingViewModel)?.Initialize(null)).ConfigureAwait(false);
    }
}
