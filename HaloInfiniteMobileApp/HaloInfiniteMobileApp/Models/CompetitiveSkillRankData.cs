using Newtonsoft.Json;

namespace HaloInfiniteMobileApp.Models
{
    public class CompetitiveSkillRankData
    {
        [JsonProperty("data")]
        public CsrQueue[] Data { get; set; }
        [JsonProperty("additional")]
        public CompetitiveSkillRankAdditional Additional { get; set; }
    }

    public class PlayerCsrsRequest{
        public PlayerCsrsRequest(string gamertag, int season = 1)
        {
            Gamertag = gamertag;
            Season = season;
        }

        [JsonProperty("gamertag")]
        public string Gamertag { get; set; }
        [JsonProperty("season")]
        public int Season { get; set; }
        }

    public class CompetitiveSkillRankAdditional
    {
        [JsonProperty("gamertag")]
        public string Gamertag { get; set; }
        [JsonProperty("season")]
        public int Season { get; set; }
    }

    public class CsrQueue
    {
        [JsonProperty("queue")]
        public string Queue { get; set; }
        [JsonProperty("input")]
        public string Input { get; set; }
        [JsonProperty("response")]
        public CsrGroups CsrGroups { get; set; }
    }

    public class CsrGroups {
        [JsonProperty("current")]
        public CsrRecord Current { get; set; }

        [JsonProperty("season")]
        public CsrRecord Season { get; set; }

        [JsonProperty("all_time")]
        public CsrRecord AllTime { get; set; }
    }

    public class CsrRecord
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("measurement_matches_remaining")]
        public int MeasurementMatchesRemaining { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("tier_start")]
        public int TierStart { get; set; }

        [JsonProperty("sub_tier")]
        public int SubTier { get; set; }

        [JsonProperty("next_tier")]
        public string NextTier { get; set; }

        [JsonProperty("next_tier_start")]
        public int NextTierStart { get; set; }

        [JsonProperty("next_sub_tier")]
        public int NextSubTier { get; set; }

        [JsonProperty("initial_measurement_matches")]
        public int InitialMeasurementMatches { get; set; }

        [JsonProperty("tier_image_url")]
        public string TierImageUrl { get; set; }
    }
}
