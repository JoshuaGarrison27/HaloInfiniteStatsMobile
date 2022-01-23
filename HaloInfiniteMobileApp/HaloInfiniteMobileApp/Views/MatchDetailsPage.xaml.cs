using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MatchDetailsPage : ContentPage
{
    public MatchDetailsPage()
    {
        InitializeComponent();
        BindingContext = DependencyService.Get<MatchDetailsViewModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is MatchDetailsViewModel)
            await ((BindingContext as MatchDetailsViewModel)?.Initialize(null)).ConfigureAwait(false);
    }
}
