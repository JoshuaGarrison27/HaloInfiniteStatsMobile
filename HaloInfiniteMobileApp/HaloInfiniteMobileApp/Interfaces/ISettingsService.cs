namespace HaloInfiniteMobileApp.Interfaces
{
    public interface ISettingsService
    {
        void AddItem(string key, string value);
        string GetItem(string key);
        void RemoveItem(string key);
    }
}