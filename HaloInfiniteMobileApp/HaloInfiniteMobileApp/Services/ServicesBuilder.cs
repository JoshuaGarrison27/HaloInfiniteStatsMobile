using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Repository;
using HaloInfiniteMobileApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HaloInfiniteMobileApp.Services;

public static class ServicesBuilder
{
    public static IServiceProvider BuildServices()
    {
        var services = new ServiceCollection();

        //ViewModels
        services.AddTransient<MainViewModel>();
        services.AddTransient<MenuViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<OnboardingViewModel>();
        services.AddTransient<HaloNewsViewModel>();
        services.AddTransient<ServiceRecordViewModel>();
        services.AddTransient<MedalsViewModel>();

        //Services
        services.AddTransient<IConnectionService, ConnectionService>();
        services.AddTransient<INavigationService, NavigationService>();
        services.AddSingleton<ISettingsService, SettingsService>();
        services.AddTransient<IDialogService, DialogService>();
        services.AddTransient<IHaloInfiniteService, HaloInfiniteService>();

        //General
        services.AddTransient<IGenericRepository, GenericRepository>();

        return services.BuildServiceProvider();
    }
}
