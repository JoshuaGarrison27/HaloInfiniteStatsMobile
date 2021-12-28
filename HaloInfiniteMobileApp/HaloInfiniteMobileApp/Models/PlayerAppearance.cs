using Newtonsoft.Json;

namespace HaloInfiniteMobileApp.Models;

public class PlayerAppearance
{
    [JsonProperty("data")]
    public PlayerIdentity PlayerIdentity { get; set; }
    [JsonProperty("additional")]
    public AdditionalAppearanceProperties Additional { get; set; }
}

public class PlayerIdentity
{
    [JsonProperty("emblem_url")]
    public string EmblemUrl { get; set; }
    [JsonProperty("backdrop_image_url")]
    public string BackdropImageUrl { get; set; }
    [JsonProperty("service_tag")]
    public string ServiceTag { get; set; }
}

public class AdditionalAppearanceProperties
{
    [JsonProperty("gamertag")]
    public string Gamertag { get; set; }
}

public class PlayerAppearanceRequest
{
    [JsonProperty("gamertag")]
    public string Gamertag { get; set; }
}
