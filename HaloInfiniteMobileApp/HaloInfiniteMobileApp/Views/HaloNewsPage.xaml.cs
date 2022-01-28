using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HaloNewsPage : ContentPage
    {
        public HaloNewsPage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<HaloNewsViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is HaloNewsViewModel)
                await ((BindingContext as HaloNewsViewModel)?.Initialize(null)).ConfigureAwait(false);
        }
    }
}