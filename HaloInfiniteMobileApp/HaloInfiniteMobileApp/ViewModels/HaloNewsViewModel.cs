using HaloInfiniteMobileApp.Extensions;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class HaloNewsViewModel : ViewModelBase
    {
        private ObservableCollection<Article> _articles;
        public HaloNewsViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService,
            IHaloInfiniteService haloInfiniteService)
            : base(connectionService, navigationService, dialogService, haloInfiniteService)
        {
        }
        public ICommand ArticleTappedCommand => new Command<Article>(OnArticleTapped);

        public ObservableCollection<Article> NewsArticles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }

        private async void OnArticleTapped(Article seletedItem)
        {
            await _dialogService.ShowDialog(seletedItem.Title, "Ok", "Ok");
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            var newsArticles = await _haloInfiniteService.GetNewsArticles();
            NewsArticles = newsArticles?.Data?.ToObservableCollection();

            IsBusy = false;
        }
    }
}
