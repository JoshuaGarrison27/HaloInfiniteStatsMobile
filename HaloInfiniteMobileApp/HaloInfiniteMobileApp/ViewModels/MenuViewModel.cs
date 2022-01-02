using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Enumerations;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

public class MenuViewModel : ViewModelBase
{
    private ObservableCollection<MainMenuItem> _menuItems;
    private PlayerAppearance _playerAppearance;
    private string _heroText;

    public MenuViewModel(IConnectionService connectionService,
        INavigationService navigationService, IDialogService dialogService,
        ISettingsService settingsService, IHaloInfiniteService haloInfiniteService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    {
        MenuItems = new ObservableCollection<MainMenuItem>();
        LoadMenuItems();
    }

    public async override Task Initialize(object data)
    {
        await base.Initialize(data);

        var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);

        if (gamertag != null)
        {
            HeroText = gamertag;
            PlayerAppearance = await _haloInfiniteService.GetPlayerAppearance(gamertag);
        }
    }

    public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

    public ObservableCollection<MainMenuItem> MenuItems
    {
        get => _menuItems;
        set
        {
            _menuItems = value;
            OnPropertyChanged();
        }
    }

    private void OnMenuItemTapped(object menuItemTappedEventArgs)
    {
        var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

        if (menuItem?.MenuText == "Change Account")
        {
            _settingsService.RemoveItem(SettingsConstants.Gamertag);
            _haloInfiniteService.InvalidateCache();
            _navigationService.ClearBackStack();
        }

        var type = menuItem?.ViewModelToLoad;
        _navigationService.NavigateToAsync(type);
    }

    private void LoadMenuItems()
    {
        MenuItems.Add(new MainMenuItem
        {
            MenuText = "Home",
            ViewModelToLoad = typeof(MainViewModel),
            MenuItemType = MenuItemType.Home,
            MenuItemIcon = "\U000F02DC"
        });

        MenuItems.Add(new MainMenuItem
        {
            MenuText = "Halo News",
            ViewModelToLoad = typeof(HaloNewsViewModel),
            MenuItemType = MenuItemType.HaloNews,
            MenuItemIcon = "\U000F1004"
        });

        MenuItems.Add(new MainMenuItem
        {
            MenuText = "Service Record",
            ViewModelToLoad = typeof(ServiceRecordViewModel),
            MenuItemType = MenuItemType.ServiceRecord,
            MenuItemIcon = "\U000F042D"
        });

        MenuItems.Add(new MainMenuItem
        {
            MenuText = "Recent Matches",
            ViewModelToLoad = typeof(PlayerMatchesViewModel),
            MenuItemType = MenuItemType.MatchList,
            MenuItemIcon = "\U000F0520"
        });

        MenuItems.Add(new MainMenuItem
        {
            MenuText = "Medals",
            ViewModelToLoad = typeof(MedalsViewModel),
            MenuItemType = MenuItemType.Medals,
            MenuItemIcon = "\U000F0987"
        });

        MenuItems.Add(new MainMenuItem
        {
            MenuText = "Change Account",
            ViewModelToLoad = typeof(OnboardingViewModel),
            MenuItemType = MenuItemType.LogOut,
            MenuItemIcon = "\U000F0343"
        });
    }

    public string HeroText
    {
        get => _heroText;
        set
        {
            _heroText = value;
            OnPropertyChanged();
        }
    }

    public PlayerAppearance PlayerAppearance
    {
        get => _playerAppearance;
        set
        {
            _playerAppearance = value;
            OnPropertyChanged();
        }
    }
}
