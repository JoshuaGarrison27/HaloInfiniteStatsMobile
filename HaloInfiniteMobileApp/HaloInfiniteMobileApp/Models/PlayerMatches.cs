using Newtonsoft.Json;
using System;

namespace HaloInfiniteMobileApp.Models;

public class PlayerMatches
{
    [JsonProperty("data")]
    public Match[] Matches { get; set; }
    public int count { get; set; }
    public Paging paging { get; set; }
    public Additional additional { get; set; }
}

public class PlayerMatchListRequest
{
    [JsonProperty("gamertag")]
    public string Gamertag { get; set; }
    [JsonProperty("limit")]
    public Paging Limit { get; set; }
    [JsonProperty("mode")]
    public string Mode { get; set; }
}

public class Paging
{
    public int count { get; set; }
    public int offset { get; set; }
}

public class Additional
{
    public string gamertag { get; set; }
    public string mode { get; set; }
}

public class Match
{
    public string id { get; set; }
    public Details details { get; set; }
    public Teams teams { get; set; }
    public Player player { get; set; }
    public string experience { get; set; }
    public DateTime played_at { get; set; }
    public Duration1 duration { get; set; }
}

public partial class Details
{
    public Category category { get; set; }
    public Map map { get; set; }
    public Playlist playlist { get; set; }
}

public partial class Category
{
    public string name { get; set; }
    public Asset asset { get; set; }
}

public partial class Asset
{
    public string id { get; set; }
    public string version { get; set; }
    public string thumbnail_url { get; set; }
}

public partial class Map
{
    public string name { get; set; }
    public Asset1 asset { get; set; }
}

public partial class Asset1
{
    public string id { get; set; }
    public string version { get; set; }
    public string thumbnail_url { get; set; }
}

public partial class Playlist
{
    public string name { get; set; }
    public Asset2 asset { get; set; }
    public Properties properties { get; set; }
}

public partial class Asset2
{
    public string id { get; set; }
    public string version { get; set; }
    public string thumbnail_url { get; set; }
}

public partial class Properties
{
    public object queue { get; set; }
    public object input { get; set; }
    public bool ranked { get; set; }
}

public partial class Teams
{
    public bool enabled { get; set; }
    public bool scoring { get; set; }
}

public partial class Player
{
    public Team team { get; set; }
    public Stats stats { get; set; }
    public int rank { get; set; }
    public string outcome { get; set; }
    public Participation participation { get; set; }
    public object progression { get; set; }
    public string MatchOutcome
    {
        get
        {
            switch (outcome)
            {
                case "draw":
                    return "Tied";
                case "win":
                    return "Victory";
                case "loss":
                    return "Defeat";
                    default: 
                    return outcome;
            }
        }
    }
}

public partial class Team
{
    public int id { get; set; }
    public string name { get; set; }
    public string emblem_url { get; set; }
}

public partial class Stats
{
    public Core core { get; set; }
    public Mode mode { get; set; }
}

public partial class Core
{
    public Summary summary { get; set; }
    public Damage damage { get; set; }
    public Shots shots { get; set; }
    public Rounds rounds { get; set; }
    public Breakdowns breakdowns { get; set; }
    public float kda { get; set; }
    public float kdr { get; set; }
    public int score { get; set; }
}

public partial class Summary
{
    public int kills { get; set; }
    public int deaths { get; set; }
    public int assists { get; set; }
    public int betrayals { get; set; }
    public int suicides { get; set; }
    public Vehicles vehicles { get; set; }
    public int medals { get; set; }
}

public partial class Vehicles
{
    public int destroys { get; set; }
    public int hijacks { get; set; }
}

public partial class Damage
{
    public int taken { get; set; }
    public int dealt { get; set; }
}

public partial class Shots
{
    public int fired { get; set; }
    public int landed { get; set; }
    public int missed { get; set; }
    public float accuracy { get; set; }
}

public partial class Rounds
{
    public int won { get; set; }
    public int lost { get; set; }
    public int tied { get; set; }
}

public partial class Breakdowns
{
    public Kills kills { get; set; }
    public Assists assists { get; set; }
    public MatchMedal[] medals { get; set; }
}

public partial class Kills
{
    public int melee { get; set; }
    public int grenades { get; set; }
    public int headshots { get; set; }
    public int power_weapons { get; set; }
}

public partial class Assists
{
    public int emp { get; set; }
    public int driver { get; set; }
    public int callouts { get; set; }
}

public class MatchMedal
{
    public long id { get; set; }
    public string name { get; set; }
    public int count { get; set; }
    public Image_Urls image_urls { get; set; }
}

public partial class Image_Urls
{
    public string small { get; set; }
    public string medium { get; set; }
    public string large { get; set; }
}

public partial class Mode
{
    public Zones zones { get; set; }
}

public partial class Zones
{
    public int secured { get; set; }
    public int captured { get; set; }
    public Occupation occupation { get; set; }
    public Kills1 kills { get; set; }
}

public partial class Occupation
{
    public int ticks { get; set; }
    public Duration duration { get; set; }
}

public partial class Duration
{
    public int seconds { get; set; }
    public string human { get; set; }
}

public partial class Kills1
{
    public int defensive { get; set; }
    public int offensive { get; set; }
}

public partial class Participation
{
    public bool joined_in_progress { get; set; }
    public Presence presence { get; set; }
}

public partial class Presence
{
    public bool beginning { get; set; }
    public bool completion { get; set; }
}

public partial class Duration1
{
    public int seconds { get; set; }
    public string human { get; set; }
}
