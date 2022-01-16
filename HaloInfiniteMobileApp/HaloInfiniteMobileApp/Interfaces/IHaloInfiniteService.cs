using HaloInfiniteMobileApp.Models;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Interfaces;

public interface IHaloInfiniteService
{
    Task<NewsArticles> GetNewsArticles();
    Task<PlayerAppearance> GetPlayerAppearance(PlayerAppearanceRequest playerAppearanceRequest);
    Task<MultiplayerServiceRecord> GetMultiplayerServiceRecord(MultiplayerServiceRecordRequest srRequest);
    Task<HaloMedals> GetHaloMedals();
    Task<PlayerMatches> GetPlayerMatches(PlayerMatchListRequest request);
    Task<MatchData> GetMatchDetails(MatchDataRequest matchRequest);
    Task<CampaignRecord> GetCampaignRecord(CampaignRequest campaignRequest);
    void InvalidateCache();
}
