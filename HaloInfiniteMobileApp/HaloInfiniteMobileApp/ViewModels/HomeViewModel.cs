using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
            //Constructor
        }

        public ICommand PieTappedCommand => new Command(DoNothing);
        public ICommand AddToCartCommand => new Command(DoNothing);

        public override async Task InitializeAsync(object data)
        {

        }

        private async void DoNothing()
        {
            await _dialogService.ShowDialog("Command Not Setup", "Failed", "OK");
        }
    }
}
