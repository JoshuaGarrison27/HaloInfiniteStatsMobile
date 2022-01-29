using System;

namespace HaloInfiniteMobileApp.Constants
{
    public static class CacheConstrants
    {
        public static readonly TimeSpan DefaultCacheTime = TimeSpan.FromMinutes(5);
        public const string PlayerAppearance = "PlayerAppearance-{0}";
        public const string NewsArticles = "NewsArticles";
        public const string MultiplayerServiceRecordPartial = "MultiplayerServiceRecord-{0}-{1}";
        public const string Medals = "Medals";
        public const string PlayerRecentMatches = "PlayerRecentMatches-{0}";
        public const string MatchDetails = "MatchDetails-{0}";
        public const string PlayerCampaign = "PlayerCampaign-{0}";
    }
}