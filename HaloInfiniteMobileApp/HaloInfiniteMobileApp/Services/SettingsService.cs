using HaloInfiniteMobileApp.Interfaces;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace HaloInfiniteMobileApp.Services;

public class SettingsService : ISettingsService
{
    private readonly ISettings _settings;

    public SettingsService()
    {
        _settings = CrossSettings.Current;
    }

    public void AddItem(string key, string value)
    {
        _settings.AddOrUpdateValue(key, value);
    }

    public string GetItem(string key)
    {
        return _settings.GetValueOrDefault(key, string.Empty);
    }

    public void RemoveItem(string key)
    {
       _settings.Remove(key);
    }
}
