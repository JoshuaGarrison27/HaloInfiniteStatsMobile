using HaloInfiniteMobileApp.Extensions;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

public class HaloNewsViewModel : ViewModelBase
{
    private ObservableCollection<Article> _articles;
    public HaloNewsViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService,
        IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService, settingsService)
    {}

    public ObservableCollection<Article> NewsArticles
    {
        get => _articles;
        set
        {
            _articles = value;
            OnPropertyChanged();
        }
    }

    public override async Task Initialize(object data)
    {
        IsBusy = true;

        var newsArticles = await _haloInfiniteService.GetNewsArticles().ConfigureAwait(false);
        NewsArticles = newsArticles?.Data?.ToObservableCollection();

        IsBusy = false;
    }
}
