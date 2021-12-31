using HaloInfiniteMobileApp.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.ViewModels.Base;

public class ViewModelBase : INotifyPropertyChanged
{
    protected readonly IConnectionService _connectionService;
    protected readonly INavigationService _navigationService;
    protected readonly IDialogService _dialogService;
    protected readonly IHaloInfiniteService _haloInfiniteService;
    protected readonly ISettingsService _settingsService;

    public ViewModelBase(IConnectionService connectionService, INavigationService navigationService,
        IDialogService dialogService, IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
    {
        _connectionService = connectionService;
        _navigationService = navigationService;
        _dialogService = dialogService;
        _haloInfiniteService = haloInfiniteService;
        _settingsService = settingsService;
    }

    private bool _isBusy;

    public event PropertyChangedEventHandler PropertyChanged;

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    //[NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public virtual Task Initialize(object data)
    {
        return Task.FromResult(false);
    }
}
