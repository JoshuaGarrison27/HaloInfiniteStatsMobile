using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels;

public class OnboardingViewModel : ViewModelBase
{
    private readonly ISettingsService _settingsService;
    private string _gamertag;

    public OnboardingViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService, IHaloInfiniteService haloInfiniteService, ISettingsService settingsService)
        : base(connectionService, navigationService, dialogService, haloInfiniteService)
    {
        _settingsService = settingsService;
    }

    public ICommand ContinueCommand => new Command(ContinueOnboarding);

    private async void ContinueOnboarding()
    {
        IsBusy = true;
        if (!string.IsNullOrWhiteSpace(Gamertag))
        {
            try
            {
                var player = await _haloInfiniteService.GetPlayerAppearance(Gamertag);

                if (player != null)
                {
                    _settingsService.AddItem(SettingsConstants.Gamertag, player.Additional.Gamertag);
                    await _navigationService.NavigateToAsync<MainViewModel>();
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
