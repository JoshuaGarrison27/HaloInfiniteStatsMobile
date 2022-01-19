using HaloInfiniteMobileApp.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels.Base;

public class ViewModelBase : INotifyPropertyChanged
{
    protected readonly IConnectionService _connectionService;
    protected readonly IDialogService _dialogService;
    protected readonly IHaloInfiniteService _haloInfiniteService;
    protected readonly ISettingsService _settingsService;
    private bool _isBusy;
    private bool _isRefreshing;
    private string _title;
    public event PropertyChangedEventHandler PropertyChanged;

    public ViewModelBase()
    {
        _connectionService = DependencyService.Get<IConnectionService>();
        _dialogService = DependencyService.Get<IDialogService>();
        _haloInfiniteService = DependencyService.Get<IHaloInfiniteService>();
        _settingsService = DependencyService.Get<ISettingsService>();
    }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set
        {
            _isRefreshing = value;
            OnPropertyChanged(nameof(IsRefreshing));
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool CheckInternetConnection(bool showToast = true)
    {
        if (!_connectionService.IsConnected && showToast)
        {
            _dialogService.ShowToast("Unable to access the internet");
        }

        return _connectionService.IsConnected;
    }

    public virtual Task Initialize(object data)
    {
        return Task.FromResult(false);
    }
}
