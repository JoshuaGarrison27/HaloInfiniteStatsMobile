using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.Models.MatchData;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Interfaces;

public interface IHaloInfiniteService
{
    Task<NewsArticles> GetNewsArticles();
    Task<PlayerAppearance> GetPlayerAppearance(string gamertag);
    Task<MultiplayerServiceRecord> GetMultiplayerServiceRecord(string gamertag, string multiplayerFilterConstants);
    Task<HaloMedals> GetHaloMedals();
    Task<PlayerMatches> GetPlayerMatches(string gamertag);
    Task<MatchDetails> GetMatchDetails(string matchId);
    void InvalidateCache();
}
