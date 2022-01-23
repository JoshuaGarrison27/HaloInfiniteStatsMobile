
using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CreditsPage : ContentPage
{
    public CreditsPage()
    {
        InitializeComponent();
        BindingContext = DependencyService.Get<CreditsViewModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is CreditsViewModel)
            await ((BindingContext as CreditsViewModel)?.Initialize(null)).ConfigureAwait(false);
    }
}
