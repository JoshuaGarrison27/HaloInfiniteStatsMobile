using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<HomeViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is HomeViewModel)
                await ((BindingContext as HomeViewModel)?.Initialize(this)).ConfigureAwait(false);
        }
    }
}