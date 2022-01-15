using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels;
using HaloInfiniteMobileApp.ViewModels.Base;
using HaloInfiniteMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Services;

public class NavigationService : INavigationService
{
    private readonly ISettingsService _settingsService;
    private readonly Dictionary<Type, Type> _mappings;

    protected Application CurrentApplication => Application.Current;

    public NavigationService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
        _mappings = new Dictionary<Type, Type>();

        CreatePageViewModelMappings();
    }

    public async Task InitializeAsync()
    {
        var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);
        if (string.IsNullOrWhiteSpace(gamertag))
        {
            await NavigateToAsync<OnboardingViewModel>();
        }
        else
        {
            await NavigateToAsync<MainViewModel>();
        }
    }

    public async Task ClearBackStack()
    {
        await CurrentApplication.MainPage.Navigation.PopToRootAsync();
    }

    public async Task NavigateBackAsync()
    {
        if (CurrentApplication.MainPage is MainView mainPage)
        {
            await mainPage.Detail.Navigation.PopAsync();
        }
        else if (CurrentApplication.MainPage != null)
        {
            await CurrentApplication.MainPage.Navigation.PopAsync();
        }
    }

    public virtual Task RemoveLastFromBackStackAsync()
    {
        if (CurrentApplication.MainPage is MainView mainPage)
        {
            mainPage.Detail.Navigation.RemovePage(
                mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
        }

        return Task.FromResult(true);
    }

    public async Task PopToRootAsync()
    {
        if (CurrentApplication.MainPage is MainView mainPage)
        {
            await mainPage.Detail.Navigation.PopToRootAsync();
        }
    }

    public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
    {
        return InternalNavigateToAsync(typeof(TViewModel), null);
    }

    public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
    {
        return InternalNavigateToAsync(typeof(TViewModel), parameter);
    }

    public Task NavigateToAsync(Type viewModelType)
    {
        return InternalNavigateToAsync(viewModelType, null);
    }

    public Task NavigateToAsync(Type viewModelType, object parameter)
    {
        return InternalNavigateToAsync(viewModelType, parameter);
    }

    protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
    {
        try
        {
            var page = CreatePage(viewModelType, parameter);

            if (page is MainView || page is OnboardingView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;

                if (mainPage.Detail is AppNavigationPage navigationPage)
                {
                    var currentPage = navigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                        await navigationPage.PushAsync(page);
                    }
                }
                else
                {
                    navigationPage = new AppNavigationPage(page);
                    mainPage.Detail = navigationPage;
                }

                mainPage.IsPresented = false;
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as AppNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new AppNavigationPage(page);
                }
            }

            await (page.BindingContext as ViewModelBase).Initialize(parameter);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }

    protected Type GetPageTypeForViewModel(Type viewModelType)
    {
        if (!_mappings.ContainsKey(viewModelType))
        {
            throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
        }

        return _mappings[viewModelType];
    }

    protected Page CreatePage(Type viewModelType, object parameter)
    {
        Type pageType = GetPageTypeForViewModel(viewModelType);

        if (pageType == null)
        {
            throw new Exception($"Mapping type for {viewModelType} is not a page");
        }

        Page page = Activator.CreateInstance(pageType) as Page;

        return page;
    }

    private void CreatePageViewModelMappings()
    {
        _mappings.Add(typeof(MainViewModel), typeof(MainView));
        _mappings.Add(typeof(MenuViewModel), typeof(MenuView));
        _mappings.Add(typeof(HomeViewModel), typeof(HomeView));
        _mappings.Add(typeof(OnboardingViewModel), typeof(OnboardingView));
        _mappings.Add(typeof(HaloNewsViewModel), typeof(HaloNewsView));
        _mappings.Add(typeof(ServiceRecordViewModel), typeof(ServiceRecordView));
        _mappings.Add(typeof(MedalsViewModel), typeof(MedalsView));
        _mappings.Add(typeof(PlayerMatchesViewModel), typeof(PlayerMatchesView));
        _mappings.Add(typeof(MatchDetailsViewModel), typeof(MatchDetailsView));
        _mappings.Add(typeof(CreditsViewModel), typeof(CreditsView));
        _mappings.Add(typeof(CampaignViewModel), typeof(CampaignView));
    }

    public IEnumerable<Page> GetNavigationStack()
    {
        if (CurrentApplication.MainPage is MainView mainPage)
        {
            return mainPage.Detail.Navigation.NavigationStack;
        }
        else if (CurrentApplication.MainPage != null)
        {
            return CurrentApplication.MainPage.Navigation.NavigationStack;
        }

        return default;
    }
}
