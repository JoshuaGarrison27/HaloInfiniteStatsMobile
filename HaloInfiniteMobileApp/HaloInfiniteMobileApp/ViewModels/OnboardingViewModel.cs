using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.ViewModels.Base;
using HaloInfiniteMobileApp.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class OnboardingViewModel : ViewModelBase
    {
        private string _gamertag;

        public ICommand ContinueCommand => new Command(ContinueOnboarding);

        private async void ContinueOnboarding()
        {
            IsBusy = true;
            if (!string.IsNullOrWhiteSpace(Gamertag))
            {
                try
                {
                    var playerAppearanceRequest = new PlayerAppearanceRequest() { Gamertag = Gamertag };
                    var player = await _haloInfiniteService.GetPlayerAppearance(playerAppearanceRequest);

                    if (player != null)
                    {
                        _settingsService.AddItem(SettingsConstants.Gamertag, player.Additional.Gamertag);
                        MessagingCenter.Send<object>(this, MessagingCenterConstants.PlayerUpdated);
                        ResetControls();
                        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                        return;
                    }
                }
                catch (Exception)
                {
                    await _dialogService.ShowDialog("Invalid Gamertag Entered", "Invalid", "Try Again");
                }
            }
            IsBusy = false;
        }

        public void ResetControls()
        {
            Gamertag = null;
            IsBusy = false;
        }

        public string Gamertag
        {
            get => _gamertag;
            set
            {
                _gamertag = value;
                OnPropertyChanged();
            }
        }
    }
}