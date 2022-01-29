using HaloInfiniteMobileApp.Extensions;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class HaloNewsViewModel : ViewModelBase
    {
        private ObservableCollection<Article> _articles;
        public HaloNewsViewModel()
        {
            Title = "Halo Infinite News";
        }

        public override async Task Initialize(object data)
        {
            IsBusy = true;

            var newsArticles = await _haloInfiniteService.GetNewsArticles().ConfigureAwait(false);
            NewsArticles = newsArticles?.Data?.ToObservableCollection();

            IsBusy = false;
        }

        public ObservableCollection<Article> NewsArticles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }
    }
}