using Akavache;
using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using HaloInfiniteMobileApp.Utilities;
using System;
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

        public NewsArticles GetNewsArticles()
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerAppearance> GetPlayerAppearance(string gamertag)
        {
            PlayerAppearance playerAppearanceFromCache = await GetFromCache<PlayerAppearance>(CacheNameConstrants.PlayerAppearance);

            if(playerAppearanceFromCache != null)
            {
                return playerAppearanceFromCache;
            } else
            {
                UriBuilder builder = new UriBuilder(HaloApiConstants.BaseApiUrl)
                {
                    Path = HaloApiConstants.AppearanceEndpoint
                };

                var apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.AppearanceEndpoint;

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
