using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using HaloInfiniteMobileApp.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class PlayerMatchesViewModel : ViewModelBase
    {
        private PlayerMatches _playerMatches;
        private bool _showLoadMoreMatchesButton = true;

        public ICommand MatchTappedCommand => new Command<Match>(OnMatchTapped);
        public ICommand LoadMoreCommand => new Command(LoadMoreMatches);
        public ICommand MatchesRefreshCommand => new AsyncCommand(() => OnPullToRefreshMatchList());

        public async override Task Initialize(object data)
        {
            IsBusy = true;
            _ = base.Initialize(data);
            await RefreshMatches().ConfigureAwait(false);
            IsBusy = false;
        }

        public async Task RefreshMatches(bool ignoreCache = false)
        {
            var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);

            if (gamertag != null)
            {
                var requestObject = new PlayerMatchListRequest(gamertag, 25, 0, "matchmade")
                {
                    IgnoreCache = ignoreCache
                };
                PlayerMatches = await _haloInfiniteService.GetPlayerMatches(requestObject).ConfigureAwait(false);
            }
        }

        private void OnMatchTapped(Match match)
        {
            Shell.Current.GoToAsync($"{nameof(MatchDetailsPage)}?MatchId={match.Id}");
        }

        private async Task OnPullToRefreshMatchList()
        {
            IsRefreshing = true;
            Vibration.Vibrate(TimeSpan.FromMilliseconds(100));
            await RefreshMatches(true).ConfigureAwait(false);
            IsRefreshing = false;
        }

        private async void LoadMoreMatches()
        {
            var matchListCount = _playerMatches.Count;
            var gamertag = _settingsService.GetItem(SettingsConstants.Gamertag);

            CheckInternetConnection();

            try
            {
                if (_connectionService.IsConnected)
                {
                    IsBusy = true;
                    var requestObject = new PlayerMatchListRequest(gamertag, 25, matchListCount, "matchmade");
                    var nextResultSet = await _haloInfiniteService.GetPlayerMatches(requestObject).ConfigureAwait(false);

                    if (nextResultSet != null && nextResultSet?.Matches?.Length > 0)
                    {
                        var mergedList = PlayerMatches.Matches.Concat(nextResultSet.Matches);
                        PlayerMatches.Matches = mergedList.ToArray();
                        OnPropertyChanged(nameof(PlayerMatches));
                    }
                    else
                    {
                        _dialogService.ShowToast("No new matches found");
                    }
                    IsBusy = false;
                }
            }
            catch (Exception)
            {
                _dialogService.ShowToast("An error occured. Please Try Again");
            }
        }

        public PlayerMatches PlayerMatches
        {
            get => _playerMatches;
            set
            {
                _playerMatches = value;
                OnPropertyChanged();
            }
        }

        public bool ShowLoadMoreMatches
        {
            get => _showLoadMoreMatchesButton;
            set
            {
                _showLoadMoreMatchesButton = value;
                OnPropertyChanged();
            }
        }
    }
}