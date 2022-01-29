using HaloInfiniteMobileApp.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand ClearCacheDataCommand => new Command(ClearCacheCommand);

        public SettingsViewModel()
        {
            Title = "Settings";
        }

        private void ClearCacheCommand()
        {
            _haloInfiniteService.InvalidateCache();
            _dialogService.ShowToast("Cleared Cache");
        }
    }
}
