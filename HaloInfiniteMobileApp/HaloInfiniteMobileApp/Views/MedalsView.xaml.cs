using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MedalsView : ContentPage
{
    public MedalsView()
    {
        InitializeComponent();
        BindingContext = DependencyService.Get<MedalsViewModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is MedalsViewModel)
            await ((BindingContext as MedalsViewModel)?.Initialize(null)).ConfigureAwait(false);
    }
}
