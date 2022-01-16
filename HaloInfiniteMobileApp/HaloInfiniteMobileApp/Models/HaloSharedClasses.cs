using Newtonsoft.Json;
using System;

namespace HaloInfiniteMobileApp.Models;

public class Match
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("details")]
    public Details Details { get; set; }
    [JsonProperty("teams")]
    public Teams Teams { get; set; }
    [JsonProperty("player")]
    public Player Player { get; set; }
    [JsonProperty("players")]
    public Player[] Players { get; set; }
    [JsonProperty("experience")]
    public string Experience { get; set; }
    [JsonProperty("played_at")]
    public DateTime PlayedAt { get; set; }
    [JsonProperty("duration")]
    public Duration Duration { get; set; }
}

public class Details
{
    [JsonProperty("category")]
    public Category Category { get; set; }
    [JsonProperty("map")]
    public Map Map { get; set; }
    [JsonProperty("playlist")]
    public Playlist Playlist { get; set; }
}

public class Asset
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("version")]
    public string Version { get; set; }
    [JsonProperty("thumbnail_url")]
    public string ThumbnailUrl { get; set; }
}

public class Category
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("asset")]
    public Asset Asset { get; set; }
}

public class Map
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("asset")]
    public Asset Asset { get; set; }
}

public class Playlist
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("asset")]
    public Asset Asset { get; set; }
    [JsonProperty("properties")]
    public Properties Properties { get; set; }
}

public class Properties
{
    [JsonProperty("queue")]
    public object Queue { get; set; }
    [JsonProperty("input")]
    public object Input { get; set; }
    [JsonProperty("ranked")]
    public bool Ranked { get; set; }
}

public class Teams
{
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }
    [JsonProperty("scoring")]
    public bool Scoring { get; set; }
    [JsonProperty("details")]
    public Detail[] details { get; set; }
}

public class Detail
{
    [JsonProperty("team")]
    public Team Team { get; set; }
    [JsonProperty("stats")]
    public Stats Stats { get; set; }
    [JsonProperty("rank")]
    public int Rank { get; set; }
    [JsonProperty("outcome")]
    public string Outcome { get; set; }
}

public class Team
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("emblem_url")]
    public string EmblemUrl { get; set; }
}

public class Stats
{
    [JsonProperty("core")]
    public Core Core { get; set; }
    [JsonProperty("mode")]
    public Mode Mode { get; set; }
}

public class Core
{
    [JsonProperty("summary")]
    public Summary Summary { get; set; }
    [JsonProperty("damage")]
    public Damage Damage { get; set; }
    [JsonProperty("shots")]
    public Shots Shots { get; set; }
    [JsonProperty("rounds")]
    public Rounds Rounds { get; set; }
    [JsonProperty("breakdowns")]
    public Breakdowns Breakdowns { get; set; }
    [JsonProperty("kda")]
    public float Kda { get; set; }
    [JsonProperty("kdr")]
    public float Kdr { get; set; }
    [JsonProperty("score")]
    public int Score { get; set; }
    [JsonProperty("points")]
    public int Points { get; set; }
}

public class Summary
{
    [JsonProperty("kills")]
    public int Kills { get; set; }
    [JsonProperty("deaths")]
    public int Deaths { get; set; }
    [JsonProperty("assists")]
    public int Assists { get; set; }
    [JsonProperty("betrayals")]
    public int Betrayals { get; set; }
    [JsonProperty("suicides")]
    public int Suicides { get; set; }
    [JsonProperty("vehicles")]
    public Vehicles Vehicles { get; set; }
    [JsonProperty("medals")]
    public int Medals { get; set; }
}

public class Vehicles
{
    [JsonProperty("destroys")]
    public int Destroys { get; set; }
    [JsonProperty("hijacks")]
    public int Hijacks { get; set; }
}

public class Damage
{
    [JsonProperty("taken")]
    public int Taken { get; set; }
    [JsonProperty("dealt")]
    public int Dealt { get; set; }
}

public class Shots
{
    [JsonProperty("fired")]
    public int Fired { get; set; }
    [JsonProperty("landed")]
    public int Landed { get; set; }
    [JsonProperty("missed")]
    public int Missed { get; set; }
    [JsonProperty("accuracy")]
    public float Accuracy { get; set; }
}

public class Rounds
{
    [JsonProperty("won")]
    public int Won { get; set; }
    [JsonProperty("lost")]
    public int Lost { get; set; }
    [JsonProperty("tied")]
    public int Tied { get; set; }
}

public class Breakdowns
{
    [JsonProperty("kills")]
    public Kills Kills { get; set; }
    [JsonProperty("assists")]
    public Assists Assists { get; set; }
    [JsonProperty("medals")]
    public Medal[] Medals { get; set; }
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
    [JsonProperty("count")]
    public int Count { get; set; }
    [JsonProperty("image_urls")]
    public Image_Urls ImageUrls { get; set; }
}

public class Kills
{
    [JsonProperty("melee")]
    public int Melee { get; set; }
    [JsonProperty("grenades")]
    public int Grenades { get; set; }
    [JsonProperty("headshots")]
    public int Headshots { get; set; }
    [JsonProperty("power_weapons")]
    public int PowerWeapons { get; set; }
}

public class Assists
{
    [JsonProperty("emp")]
    public int Emp { get; set; }
    [JsonProperty("driver")]
    public int Driver { get; set; }
    [JsonProperty("callouts")]
    public int Callouts { get; set; }
}

public class Image_Urls
{
    [JsonProperty("small")]
    public string Small { get; set; }
    [JsonProperty("medium")]
    public string Medium { get; set; }
    [JsonProperty("large")]
    public string Large { get; set; }
}

public class Mode
{
    [JsonProperty("zones")]
    public Zones Zones { get; set; }
    [JsonProperty("flags")]
    public Flags Flags { get; set; }
}

public class GameMode
{
}

public class Flags : GameMode
{
    [JsonProperty("grabs")]
    public int Grabs { get; set; }
    [JsonProperty("steals")]
    public int Steals { get; set; }
    [JsonProperty("secures")]
    public int Secures { get; set; }
    [JsonProperty("returns")]
    public int Returns { get; set; }
    [JsonProperty("possession")]
    public Possession Possession { get; set; }
    [JsonProperty("captures")]
    public Captures Captures { get; set; }
    [JsonProperty("kills")]
    public FlagKills Kills { get; set; }
}

public class Possession
{
    [JsonProperty("duration")]
    public Duration Duration { get; set; }
}

public class Captures
{
    [JsonProperty("total")]
    public int Total { get; set; }
    [JsonProperty("assists")]
    public int Assists { get; set; }
}

public class FlagKills
{
    [JsonProperty("carriers")]
    public int Carriers { get; set; }
    [JsonProperty("returners")]
    public int Returners { get; set; }
    [JsonProperty("as")]
    public KillsAs As { get; set; }
}

public class KillsAs
{
    [JsonProperty("carrier")]
    public int Carrier { get; set; }
    [JsonProperty("returner")]
    public int Returner { get; set; }
}

public class Zones : GameMode
{
    [JsonProperty("secured")]
    public int secured { get; set; }
    [JsonProperty("captured")]
    public int captured { get; set; }
    [JsonProperty("occupation")]
    public Occupation occupation { get; set; }
    [JsonProperty("kills")]
    public ZoneKills kills { get; set; }
}

public class Occupation
{
    [JsonProperty("ticks")]
    public int Ticks { get; set; }
    [JsonProperty("duration")]
    public Duration Duration { get; set; }
}

public class Duration
{
    [JsonProperty("seconds")]
    public int Seconds { get; set; }
    [JsonProperty("human")]
    public string Human { get; set; }
}

public class ZoneKills
{
    [JsonProperty("defensive")]
    public int Defensive { get; set; }
    [JsonProperty("offensive")]
    public int Offensive { get; set; }
}

public class Player
{
    [JsonProperty("gamertag")]
    public string Gamertag { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("team")]
    public Team Team { get; set; }
    [JsonProperty("stats")]
    public Stats Stats { get; set; }
    [JsonProperty("rank")]
    public int Rank { get; set; }
    [JsonProperty("outcome")]
    public string Outcome { get; set; }
    [JsonProperty("participation")]
    public Participation Participation { get; set; }
    [JsonProperty("progression")]
    public Progression Progression { get; set; }
    [JsonIgnore]
    public string MatchOutcome
    {
        get
        {
            return Outcome switch
            {
                "draw" => "Tied",
                "win" => "Victory",
                "loss" => "Defeat",
                _ => Outcome,
            };
        }
    }
}

public class Participation
{
    [JsonProperty("joined_in_progress")]
    public bool JoinedInProgress { get; set; }
    [JsonProperty("presence")]
    public Presence Presence { get; set; }
}

public class Presence
{
    [JsonProperty("beginning")]
    public bool Beginning { get; set; }
    [JsonProperty("completion")]
    public bool Completion { get; set; }
}

public class Progression
{
    [JsonProperty("csr")]
    public Csr Csr { get; set; }
}

public class Csr
{
    [JsonProperty("pre_match")]
    public PreMatch PreMatch { get; set; }
    [JsonProperty("post_match")]
    public PostMatch PostMatch { get; set; }
}

public class PreMatch
{
    [JsonProperty("tier")]
    public string Tier { get; set; }
    [JsonProperty("value")]
    public int Value { get; set; }
    [JsonProperty("tier_start")]
    public int TierStart { get; set; }
    [JsonProperty("sub_tier")]
    public int SubTier { get; set; }
    [JsonProperty("tier_image_url")]
    public string TierImageUrl { get; set; }
}

public class PostMatch
{
    [JsonProperty("tier")]
    public string Tier { get; set; }
    [JsonProperty("value")]
    public int Value { get; set; }
    [JsonProperty("tier_start")]
    public int TierStart { get; set; }
    [JsonProperty("sub_tier")]
    public int SubTier { get; set; }
    [JsonProperty("tier_image_url")]
    public string TierImageUrl { get; set; }
}
