using HaloInfiniteMobileApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Interfaces;

public interface INavigationService
{
    Task InitializeAsync();

    Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

    Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

    Task NavigateToAsync(Type viewModelType);

    Task ClearBackStack();

    Task NavigateToAsync(Type viewModelType, object parameter);

    Task NavigateBackAsync();

    Task RemoveLastFromBackStackAsync();

    Task PopToRootAsync();

    IEnumerable<Page> GetNavigationStack();
}
