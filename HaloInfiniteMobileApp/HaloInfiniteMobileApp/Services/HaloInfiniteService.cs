using Akavache;
using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Services
{
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
            NewsArticles newsArticlesFromCache = await GetFromCache<NewsArticles>(CacheNameConstrants.NewsArticles);

            if(newsArticlesFromCache != null)
            {
                return newsArticlesFromCache;
            } else
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
            PlayerAppearance playerAppearanceFromCache = await GetFromCache<PlayerAppearance>(CacheNameConstrants.PlayerAppearance);

            if(playerAppearanceFromCache != null)
            {
                return playerAppearanceFromCache;
            } else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.AppearanceEndpoint;
                var playerAppearanceRequest = new PlayerAppearanceRequest
                {
                    Gamertag = gamertag
                };

                var playerAppearance = await _genericRepository.PostAsync<PlayerAppearanceRequest, PlayerAppearance>(apiUrl, playerAppearanceRequest, _haloApiAuthToken);

                Cache.InsertObject(CacheNameConstrants.PlayerAppearance, playerAppearance, DateTimeOffset.Now.AddMinutes(2));

                return playerAppearance;
            }
        }

        public void InvalidateHaloCache()
        {
            InvalidateCacheKey(CacheNameConstrants.PlayerAppearance);
        }
    }
}
