using HaloInfiniteMobileApp.Models;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Interfaces;

public interface IHaloInfiniteService
{
    Task<NewsArticles> GetNewsArticles();
    Task<PlayerAppearance> GetPlayerAppearance(string gamertag);
    Task<MultiplayerServiceRecord> GetMultiplayerServiceRecord(string gamertag, string multiplayerFilterConstants);
    Task<HaloMedals> GetHaloMedals();
    void InvalidateCache();
}
