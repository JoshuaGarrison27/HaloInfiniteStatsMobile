using Acr.UserDialogs;
using HaloInfiniteMobileApp.Interfaces;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowDialog(string message, string title, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }

        public async Task<bool> ShowDialogYesNoQuestion(string title, string message, string accept, string cancel)
        {
            return await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public void ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
    }
}