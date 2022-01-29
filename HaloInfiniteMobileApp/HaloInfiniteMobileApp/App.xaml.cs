using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Repository;
using HaloInfiniteMobileApp.Services;
using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MonkeyCache.FileStore;
using Xamarin.Essentials;

namespace HaloInfiniteMobileApp
{
    public partial class App : Application
    {
        public static System.IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            InitializeComponent();
            RegisterDependencies();
            Barrel.ApplicationId = AppInfo.PackageName;
            MainPage = new AppShell();
        }

        private void RegisterDependencies()
        {
            //ViewModels
            DependencyService.Register<HomeViewModel>();
            DependencyService.Register<OnboardingViewModel>();
            DependencyService.Register<HaloNewsViewModel>();
            DependencyService.Register<ServiceRecordViewModel>();
            DependencyService.Register<MedalsViewModel>();
            DependencyService.Register<PlayerMatchesViewModel>();
            DependencyService.Register<MatchDetailsViewModel>();
            DependencyService.Register<CreditsViewModel>();
            DependencyService.Register<CampaignViewModel>();
            DependencyService.Register<SettingsViewModel>();

            //Services
            DependencyService.RegisterSingleton<ISettingsService>(new SettingsService());
            DependencyService.Register<IConnectionService, ConnectionService>();
            DependencyService.Register<IDialogService, DialogService>();
            DependencyService.Register<IHaloInfiniteService, HaloInfiniteService>();

            //General
            DependencyService.Register<IGenericRepository, GenericRepository>();
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