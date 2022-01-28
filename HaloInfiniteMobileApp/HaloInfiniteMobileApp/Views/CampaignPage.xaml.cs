using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CampaignPage : ContentPage
    {
        public CampaignPage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<CampaignViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is CampaignViewModel)
                await ((BindingContext as CampaignViewModel)?.Initialize(null)).ConfigureAwait(false);
        }
    }
}