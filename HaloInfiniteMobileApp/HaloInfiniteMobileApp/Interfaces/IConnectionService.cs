using Plugin.Connectivity.Abstractions;

namespace HaloInfiniteMobileApp.Interfaces;

public interface IConnectionService
{
    bool IsConnected { get; }
    event ConnectivityChangedEventHandler ConnectivityChanged;
}
