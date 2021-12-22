using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Repository;
using HaloInfiniteMobileApp.Services;
using HaloInfiniteMobileApp.ViewModels;
using HaloInfiniteMobileApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp
{
    public partial class App : Application
    {
        public static System.IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            InitializeComponent();

            SetupServices();

            InitializeNavigation();
        }

        void SetupServices()
        {
            var services = new ServiceCollection();

            //ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<MenuViewModel>();
            services.AddTransient<HomeViewModel>();

            //Services
            services.AddTransient<IConnectionService, ConnectionService>();
            services.AddTransient<INavigationService, NavigationService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddTransient<IDialogService, DialogService>();

            //General
            services.AddTransient<IGenericRepository, GenericRepository>();

            ServiceProvider = services.BuildServiceProvider();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = ServiceProvider.GetService<INavigationService>();
            await navigationService.InitializeAsync();
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
}
