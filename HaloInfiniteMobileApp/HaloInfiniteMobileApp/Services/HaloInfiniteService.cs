using Akavache;
using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using System;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Services
{
    public class HaloInfiniteService : BaseService, IHaloInfiniteService
    {
        private readonly IGenericRepository _genericRepository;
        private const string HaloApiAuthToken = "tok_dev_nPKdkn5CgUXNbXd38NKAK4eZXfXJg4C8k13FSM8FAVT6UpxGovCeUsSujwQHpK7N";

        public HaloInfiniteService(IGenericRepository genericRepository, IBlobCache cache = null) : base(cache)
        {
            _genericRepository = genericRepository;
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

                var playerAppearance = await _genericRepository.PostAsync<PlayerAppearanceRequest, PlayerAppearance>(apiUrl, playerAppearanceRequest, HaloApiAuthToken);

                Cache.InsertObject(CacheNameConstrants.PlayerAppearance, playerAppearance, DateTimeOffset.Now.AddMinutes(2));

                return playerAppearance;
            }
        }
    }
}
