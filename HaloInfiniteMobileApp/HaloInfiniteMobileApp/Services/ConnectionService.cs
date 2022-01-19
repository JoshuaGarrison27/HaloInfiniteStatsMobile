using HaloInfiniteMobileApp.Interfaces;
using Xamarin.Essentials;

namespace HaloInfiniteMobileApp.Services;

public class ConnectionService : IConnectionService
{
    public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet || Connectivity.NetworkAccess == NetworkAccess.ConstrainedInternet;
}
