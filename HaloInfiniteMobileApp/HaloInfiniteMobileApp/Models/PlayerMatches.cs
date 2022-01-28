using Newtonsoft.Json;

namespace HaloInfiniteMobileApp.Models
{
    public class PlayerMatches
    {
        [JsonProperty("data")]
        public Match[] Matches { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
        [JsonProperty("additional")]
        public AdditionalMatchProperties Additional { get; set; }
    }

    public class PlayerMatchListRequest : ServiceRequestBase
    {
        public PlayerMatchListRequest(string gamertag, int count = 10, int offset = 0, string mode = "matchmade")
        {
            Gamertag = gamertag;
            Limit = new Paging
            {
                Count = count,
                Offset = offset,
            };
            Mode = mode;
        }

        [JsonProperty("gamertag")]
        public string Gamertag { get; set; }
        [JsonProperty("limit")]
        public Paging Limit { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
    }

    public class Paging
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }

    public class AdditionalMatchProperties
    {
        [JsonProperty("gamertag")]
        public string Gamertag { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
    }
}