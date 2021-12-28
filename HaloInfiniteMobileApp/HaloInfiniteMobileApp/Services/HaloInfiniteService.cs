using Akavache;
using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.Utilities;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace HaloInfiniteMobileApp.Services;

public class HaloInfiniteService : BaseService, IHaloInfiniteService
{
    private readonly IGenericRepository _genericRepository;
    private readonly string _haloApiAuthToken;

    public HaloInfiniteService(IGenericRepository genericRepository, IBlobCache cache = null) : base(cache)
    {
        _genericRepository = genericRepository;
        _haloApiAuthToken = UserSecretsManager.Settings["HaloApiToken"] ?? string.Empty;
    }

    public async Task<NewsArticles> GetNewsArticles()
    {
        var newsArticlesFromCache = await GetFromCache<NewsArticles>(CacheNameConstrants.NewsArticles);

        if (newsArticlesFromCache != null)
        {
            return newsArticlesFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.Articles;
            var newsArticlesRequest = new NewsArticlesRequest();

            var newsArticles = await _genericRepository.PostAsync<NewsArticlesRequest, NewsArticles>(apiUrl, newsArticlesRequest, _haloApiAuthToken);

            Cache.InsertObject(CacheNameConstrants.NewsArticles, newsArticles, DateTimeOffset.Now.AddMinutes(2));

            return newsArticles;
        }
    }

    public async Task<PlayerAppearance> GetPlayerAppearance(string gamertag)
    {
        var playerAppearanceFromCache = await GetFromCache<PlayerAppearance>(CacheNameConstrants.PlayerAppearance);

        if (playerAppearanceFromCache != null)
        {
            return playerAppearanceFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.Appearance;
            var playerAppearanceRequest = new PlayerAppearanceRequest
            {
                Gamertag = gamertag
            };

            var playerAppearance = await _genericRepository.PostAsync<PlayerAppearanceRequest, PlayerAppearance>(apiUrl, playerAppearanceRequest, _haloApiAuthToken);

            Cache.InsertObject(CacheNameConstrants.PlayerAppearance, playerAppearance, DateTimeOffset.Now.AddMinutes(2));

            return playerAppearance;
        }
    }

    public async Task<MultiplayerServiceRecord> GetMultiplayerServiceRecord(string gamertag, string multiplayerFilterConstants = MultiplayerFilterConstants.Matchmade_Ranked)
    {
        var cacheKey = CacheNameConstrants.MultiplayerServiceRecordPartial + multiplayerFilterConstants;
        var multiplayerSRFromCache = await GetFromCache<MultiplayerServiceRecord>(cacheKey);

        if (multiplayerSRFromCache != null)
        {
            return multiplayerSRFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.ServiceRecordMultiplayer;
            var requestObject = new MultiplayerServiceRecordRequest
            {
                Gamertag = gamertag,
                Filter = multiplayerFilterConstants
            };

            var response = await _genericRepository.PostAsync<MultiplayerServiceRecordRequest, MultiplayerServiceRecord>(apiUrl, requestObject, _haloApiAuthToken);

            Cache.InsertObject(cacheKey, response, DateTimeOffset.Now.AddMinutes(5));

            return response;
        }
    }

    public async Task<HaloMedals> GetHaloMedals()
    {
        const string cacheKey = CacheNameConstrants.Medals;
        var medalsFromCache = await GetFromCache<HaloMedals>(cacheKey);

        if (medalsFromCache != null)
        {
            return medalsFromCache;
        }
        else
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.MedalsList;

            var response = await _genericRepository.GetAsync<HaloMedals>(apiUrl, _haloApiAuthToken);

            Cache.InsertObject(cacheKey, response, DateTimeOffset.Now.AddDays(1));

            return response;
        }
    }
}
