using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using HaloInfiniteMobileApp.Extensions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.ViewModels;

public class MedalsViewModel : ViewModelBase
{
    private ObservableCollection<Medal> _haloMedals;

    public MedalsViewModel(IConnectionService connectionService,
        INavigationService navigationService, IDialogService dialogService, IHaloInfiniteService haloInfiniteService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService)
    {}

    public async override Task Initialize(object data)
    {
        _ = base.Initialize(data);

        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        var apiMedals = await _haloInfiniteService.GetHaloMedals();
        Medals = apiMedals.Medals.OrderBy(o => o.Name).ToObservableCollection();
    }

    public ObservableCollection<Medal> Medals
    {
        get => _haloMedals;
        set
        {
            _haloMedals = value;
            OnPropertyChanged();
        }
    }
}
