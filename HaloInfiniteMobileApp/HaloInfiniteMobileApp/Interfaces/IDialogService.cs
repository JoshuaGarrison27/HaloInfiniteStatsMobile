using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Interfaces
{
    public interface IDialogService
    {
        Task ShowDialog(string message, string title, string buttonLabel);
        Task<bool> ShowDialogYesNoQuestion(string title, string message, string accept, string cancel);
        void ShowToast(string message);
    }
}