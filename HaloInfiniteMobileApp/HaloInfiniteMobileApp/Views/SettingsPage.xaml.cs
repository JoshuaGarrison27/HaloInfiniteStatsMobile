using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<SettingsViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is SettingsViewModel)
                await ((BindingContext as SettingsViewModel)?.Initialize(this)).ConfigureAwait(false);
        }
    }
}