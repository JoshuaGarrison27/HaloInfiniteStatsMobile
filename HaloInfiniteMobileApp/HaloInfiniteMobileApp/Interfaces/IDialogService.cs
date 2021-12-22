using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Interfaces
{
    public interface IDialogService
    {
        Task ShowDialog(string message, string title, string buttonLabel);
        void ShowToast(string message);
    }
}
