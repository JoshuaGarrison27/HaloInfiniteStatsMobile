using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HomeView : ContentPage
{
    public HomeView()
    {
        InitializeComponent();
        BindingContext = DependencyService.Get<HomeViewModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if(BindingContext is HomeViewModel)
            await ((BindingContext as HomeViewModel)?.Initialize(null)).ConfigureAwait(false);
    }
}
