using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels.Base;
using HaloInfiniteMobileApp.Views;
using System.Linq;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private MenuViewModel _menuViewModel;

    public MainViewModel(IConnectionService connectionService,
        INavigationService navigationService, IDialogService dialogService,
        MenuViewModel menuViewModel, IHaloInfiniteService haloInfiniteService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService)
    {
        _menuViewModel = menuViewModel;
    }

    public MenuViewModel MenuViewModel
    {
        get => _menuViewModel;
        set
        {
            _menuViewModel = value;
            OnPropertyChanged();
        }
    }

    public override async Task Initialize(object data)
    {
        var pages = _navigationService.GetNavigationStack().ToList();

        if (pages.Any(page => page.GetType() == typeof(HomeView)))
        {
            await Task.WhenAll
            (
                _menuViewModel.Initialize(data)
            );
        }
        else
        {
            await Task.WhenAll
            (
                _menuViewModel.Initialize(data),
                _navigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}
