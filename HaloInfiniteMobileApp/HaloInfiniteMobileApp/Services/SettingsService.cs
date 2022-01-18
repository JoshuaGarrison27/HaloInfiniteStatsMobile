using HaloInfiniteMobileApp.Interfaces;
using Xamarin.Essentials;

namespace HaloInfiniteMobileApp.Services;

public class SettingsService : ISettingsService
{
    public void AddItem(string key, string value)
    {
        Preferences.Set(key, value);
    }

    public string GetItem(string key)
    {
        return Preferences.Get(key, string.Empty);
    }

    public void RemoveItem(string key)
    {
        Preferences.Remove(key);
    }

    public void ClearAll()
    {
        Preferences.Clear();
    }
}
