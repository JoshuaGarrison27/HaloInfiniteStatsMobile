using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Helpers;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Services
{
    public class HaloInfiniteService : BaseService, IHaloInfiniteService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly string _haloApiAuthToken;

        public HaloInfiniteService()
        {
            _genericRepository = DependencyService.Get<IGenericRepository>();
            _haloApiAuthToken = Secrets.HaloApiToken;
        }

        public async Task<NewsArticles> GetNewsArticles()
        {
            const string cacheKey = CacheConstrants.NewsArticles;
            var newsArticlesFromCache = GetFromCache<NewsArticles>(cacheKey);

            if (newsArticlesFromCache != null)
            {
                return newsArticlesFromCache;
            }
            else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.Articles;
                var newsArticlesRequest = new NewsArticlesRequest();

                var newsArticles = await _genericRepository.PostAsync<NewsArticlesRequest, NewsArticles>(apiUrl, newsArticlesRequest, _haloApiAuthToken).ConfigureAwait(false);

                AddToCache(cacheKey, newsArticles, CacheConstrants.DefaultCacheTime);

                return newsArticles;
            }
        }

        public async Task<PlayerAppearance> GetPlayerAppearance(PlayerAppearanceRequest playerAppearanceRequest)
        {
            var cacheKey = string.Format(CacheConstrants.PlayerAppearance, playerAppearanceRequest.Gamertag);
            var playerAppearanceFromCache = GetFromCache<PlayerAppearance>(cacheKey);

            if (playerAppearanceFromCache != null)
            {
                return playerAppearanceFromCache;
            }
            else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.Appearance;

                var playerAppearance = await _genericRepository.PostAsync<PlayerAppearanceRequest, PlayerAppearance>(apiUrl, playerAppearanceRequest, _haloApiAuthToken).ConfigureAwait(false);

                AddToCache(cacheKey, playerAppearance, CacheConstrants.DefaultCacheTime);

                return playerAppearance;
            }
        }

        public async Task<MultiplayerServiceRecord> GetMultiplayerServiceRecord(MultiplayerServiceRecordRequest srRequest)
        {
            var cacheKey = string.Format(CacheConstrants.MultiplayerServiceRecordPartial, srRequest.Gamertag, srRequest.Filter);
            var multiplayerSRFromCache = GetFromCache<MultiplayerServiceRecord>(cacheKey);

            if (multiplayerSRFromCache != null)
            {
                return multiplayerSRFromCache;
            }
            else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.ServiceRecordMultiplayer;

                var response = await _genericRepository.PostAsync<MultiplayerServiceRecordRequest, MultiplayerServiceRecord>(apiUrl, srRequest, _haloApiAuthToken).ConfigureAwait(false);

                AddToCache(cacheKey, response, CacheConstrants.DefaultCacheTime);

                return response;
            }
        }

        public async Task<HaloMedals> GetHaloMedals()
        {
            const string cacheKey = CacheConstrants.Medals;
            var medalsFromCache = GetFromCache<HaloMedals>(cacheKey);

            if (medalsFromCache != null)
            {
                return medalsFromCache;
            }
            else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.MedalsList;

                var response = await _genericRepository.GetAsync<HaloMedals>(apiUrl, _haloApiAuthToken).ConfigureAwait(false);

                AddToCache(cacheKey, response, CacheConstrants.DefaultCacheTime);

                return response;
            }
        }

        public async Task<PlayerMatches> GetPlayerMatches(PlayerMatchListRequest request)
        {
            const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.MatchList;
            return await _genericRepository.PostAsync<PlayerMatchListRequest, PlayerMatches>(apiUrl, request, _haloApiAuthToken).ConfigureAwait(false);
        }

        public async Task<MatchData> GetMatchDetails(MatchDataRequest matchRequest)
        {
            string cacheKey = string.Format(CacheConstrants.MatchDetails, matchRequest.Id);
            var matchDetailsFromCache = GetFromCache<MatchData>(cacheKey);

            if (matchDetailsFromCache != null)
            {
                return matchDetailsFromCache;
            }
            else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.MatchRetrieve;

                var response = await _genericRepository.PostAsync<MatchDataRequest, MatchData>(apiUrl, matchRequest, _haloApiAuthToken).ConfigureAwait(false);

                AddToCache(cacheKey, response, TimeSpan.FromDays(1));

                return response;
            }
        }

        public async Task<CampaignRecord> GetCampaignRecord(CampaignRequest campaignRequest)
        {
            var cacheKey = string.Format(CacheConstrants.PlayerCampaign, campaignRequest.Gamertag);
            var playerCampaignFromCache = GetFromCache<CampaignRecord>(cacheKey);

            if (playerCampaignFromCache != null)
            {
                return playerCampaignFromCache;
            }
            else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.CampaignRecord;

                var playerCampaign = await _genericRepository.PostAsync<CampaignRequest, CampaignRecord>(apiUrl, campaignRequest, _haloApiAuthToken).ConfigureAwait(false);

                AddToCache(cacheKey, playerCampaign, CacheConstrants.DefaultCacheTime);

                return playerCampaign;
            }
        }

        public async Task<CompetitiveSkillRankData> GetPlayerCsrs(PlayerCsrsRequest csrsRequest)
        {
            var cacheKey = string.Format(CacheConstrants.PlayerCsrs, csrsRequest.Gamertag);
            var playerCsrsFromCache = GetFromCache<CompetitiveSkillRankData>(cacheKey);

            if (playerCsrsFromCache != null)
            {
                return playerCsrsFromCache;
            }
            else
            {
                const string apiUrl = HaloApiConstants.BaseApiUrl + HaloApiConstants.Csrs;

                var playerCsrs = await _genericRepository.PostAsync<PlayerCsrsRequest, CompetitiveSkillRankData>(apiUrl, csrsRequest, _haloApiAuthToken).ConfigureAwait(false);

                AddToCache(cacheKey, playerCsrs, CacheConstrants.DefaultCacheTime);

                return playerCsrs;
            }
        }
    }
}