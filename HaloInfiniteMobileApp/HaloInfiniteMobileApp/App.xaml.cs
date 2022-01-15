using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp;

public partial class App : Application
{
    public static System.IServiceProvider ServiceProvider { get; set; }

    public App()
    {
        InitializeComponent();

        ServiceProvider = ServicesBuilder.BuildServices();

        _ = InitializeNavigation();
    }

    private async Task InitializeNavigation()
    {
        var navigationService = ServiceProvider.GetService<INavigationService>();
        await navigationService.InitializeAsync().ConfigureAwait(false);
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
}
