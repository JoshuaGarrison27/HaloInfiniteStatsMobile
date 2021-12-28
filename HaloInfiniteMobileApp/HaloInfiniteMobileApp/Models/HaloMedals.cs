using Newtonsoft.Json;
using System.Collections.Generic;

namespace HaloInfiniteMobileApp.Models;
public class HaloMedals
{
    [JsonProperty("data")]
    public IEnumerable<Medal> Medals { get; set; }
}

public class Medal
{
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("image_urls")]
    public MedalImages Image { get; set; }
}

public class MedalImages
{
    [JsonProperty("small")]
    public string Small { get; set; }
    [JsonProperty("medium")]
    public string Medium { get; set; }
    [JsonProperty("large")]
    public string Large { get; set; }
}
