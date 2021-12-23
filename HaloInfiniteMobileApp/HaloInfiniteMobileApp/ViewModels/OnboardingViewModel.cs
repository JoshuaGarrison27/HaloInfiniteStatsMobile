using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class OnboardingViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private string _gamertag;

        public OnboardingViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService)
            : base(connectionService, navigationService, dialogService)
        {
            _settingsService = settingsService;
        }

        public ICommand ContinueCommand => new Command(ContinueOnboarding);

        private void ContinueOnboarding()
        {
            if (!string.IsNullOrWhiteSpace(Gamertag))
            {
                _settingsService.AddItem(SettingsConstants.Gamertag, Gamertag);
                _navigationService.NavigateToAsync<MainViewModel>();
            }
            else
            {
                _dialogService.ShowToast("Invalid Gamertag Entered");
            }
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
