using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ServiceRecordView : TabbedPage
{
    public ServiceRecordView()
    {
        InitializeComponent();
        BindingContext = DependencyService.Get<ServiceRecordViewModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ServiceRecordViewModel)
            await ((BindingContext as ServiceRecordViewModel)?.Initialize(null)).ConfigureAwait(false);
    }
}
