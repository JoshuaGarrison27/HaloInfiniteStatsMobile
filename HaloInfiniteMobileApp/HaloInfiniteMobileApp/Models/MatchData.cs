using Newtonsoft.Json;

namespace HaloInfiniteMobileApp.Models
{
    public class MatchData
    {
        [JsonProperty("data")]
        public Match Match { get; set; }
    }

    public class MatchDataRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}