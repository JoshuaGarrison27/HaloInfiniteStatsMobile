using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels.Base;

namespace HaloInfiniteMobileApp.ViewModels;

public class CreditsViewModel : ViewModelBase
{
    public CreditsViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService,
        IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    { }
}
