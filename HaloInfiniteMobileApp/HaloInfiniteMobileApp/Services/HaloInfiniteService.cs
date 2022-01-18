using Akavache;
using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.Utilities;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Services;

public class HaloInfiniteService : BaseService, IHaloInfiniteService
{
    private readonly IGenericRepository _genericRepository;
    private readonly string _haloApiAuthToken;

    public HaloInfiniteService() : base(null)
    {
        _genericRepository = DependencyService.Get<IGenericRepository>();
        _haloApiAuthToken = UserSecretsManager.Settings["HaloApiToken"] ?? string.Empty;
    }

    public async Task<NewsArticles> GetNewsArticles()
    {
        var newsArticlesFromCache = await GetFromCache<NewsArticles>(CacheNameConstrants.NewsArticles).ConfigureAwait(false);

        if (newsArticlesFromCache != null)
        {
            return newsArticlesFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.Articles;
            var newsArticlesRequest = new NewsArticlesRequest();

            var newsArticles = await _genericRepository.PostAsync<NewsArticlesRequest, NewsArticles>(apiUrl, newsArticlesRequest, _haloApiAuthToken).ConfigureAwait(false);

            Cache.InsertObject(CacheNameConstrants.NewsArticles, newsArticles, DateTimeOffset.Now.AddMinutes(2));

            return newsArticles;
        }
    }

    public async Task<PlayerAppearance> GetPlayerAppearance(PlayerAppearanceRequest playerAppearanceRequest)
    {
        var playerAppearanceFromCache = await GetFromCache<PlayerAppearance>(CacheNameConstrants.PlayerAppearance).ConfigureAwait(false);

        if (playerAppearanceFromCache != null)
        {
            return playerAppearanceFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.Appearance;

            var playerAppearance = await _genericRepository.PostAsync<PlayerAppearanceRequest, PlayerAppearance>(apiUrl, playerAppearanceRequest, _haloApiAuthToken).ConfigureAwait(false);

            Cache.InsertObject(CacheNameConstrants.PlayerAppearance, playerAppearance, DateTimeOffset.Now.AddMinutes(2));

            return playerAppearance;
        }
    }

    public async Task<MultiplayerServiceRecord> GetMultiplayerServiceRecord(MultiplayerServiceRecordRequest srRequest)
    {
        var cacheKey = CacheNameConstrants.MultiplayerServiceRecordPartial + srRequest.Filter;
        var multiplayerSRFromCache = await GetFromCache<MultiplayerServiceRecord>(cacheKey).ConfigureAwait(false);

        if (multiplayerSRFromCache != null)
        {
            return multiplayerSRFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.ServiceRecordMultiplayer;

            var response = await _genericRepository.PostAsync<MultiplayerServiceRecordRequest, MultiplayerServiceRecord>(apiUrl, srRequest, _haloApiAuthToken).ConfigureAwait(false);

            Cache.InsertObject(cacheKey, response, DateTimeOffset.Now.AddMinutes(5));

            return response;
        }
    }

    public async Task<HaloMedals> GetHaloMedals()
    {
        const string cacheKey = CacheNameConstrants.Medals;
        var medalsFromCache = await GetFromCache<HaloMedals>(cacheKey).ConfigureAwait(false);

        if (medalsFromCache != null)
        {
            return medalsFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.MedalsList;

            var response = await _genericRepository.GetAsync<HaloMedals>(apiUrl, _haloApiAuthToken).ConfigureAwait(false);

            Cache.InsertObject(cacheKey, response, DateTimeOffset.Now.AddDays(1));

            return response;
        }
    }

    public async Task<PlayerMatches> GetPlayerMatches(PlayerMatchListRequest request)
    {
        var cacheKey = CacheNameConstrants.PlayerMatchesPartial + request.Gamertag;
        var playerMatchesFromCache = await GetFromCache<PlayerMatches>(cacheKey).ConfigureAwait(false);

        if (playerMatchesFromCache != null && !request.IgnoreCache)
        {
            return playerMatchesFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.MatchList;

            var response = await _genericRepository.PostAsync<PlayerMatchListRequest, PlayerMatches>(apiUrl, request, _haloApiAuthToken).ConfigureAwait(false);

            Cache.InsertObject(cacheKey, response, DateTimeOffset.Now.AddMinutes(5));

            return response;
        }
    }

    public async Task<MatchData> GetMatchDetails(MatchDataRequest matchRequest)
    {
        string cacheKey = matchRequest.Id;
        var matchDetailsFromCache = await GetFromCache<MatchData>(cacheKey).ConfigureAwait(false);

        if (matchDetailsFromCache != null)
        {
            return matchDetailsFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.MatchRetrieve;

            var response = await _genericRepository.PostAsync<MatchDataRequest, MatchData>(apiUrl, matchRequest, _haloApiAuthToken).ConfigureAwait(false);

            Cache.InsertObject(cacheKey, response, DateTimeOffset.Now.AddDays(1));

            return response;
        }
    }

    public async Task<CampaignRecord> GetCampaignRecord(CampaignRequest campaignRequest)
    {
        var playerCampaignFromCache = await GetFromCache<CampaignRecord>(CacheNameConstrants.PlayerCampaign).ConfigureAwait(false);

        if (playerCampaignFromCache != null)
        {
            return playerCampaignFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.CampaignRecord;

            var playerCampaign = await _genericRepository.PostAsync<CampaignRequest, CampaignRecord>(apiUrl, campaignRequest, _haloApiAuthToken).ConfigureAwait(false);

            Cache.InsertObject(CacheNameConstrants.PlayerCampaign, playerCampaign, DateTimeOffset.Now.AddMinutes(5));

            return playerCampaign;
        }
    }
}
