using Newtonsoft.Json;

namespace HaloInfiniteMobileApp.Models;

public class MultiplayerServiceRecord
{
    [JsonProperty("data")]
    public MultiplayerServiceRecordData Data { get; set; }
    [JsonProperty("additional")]
    public MultiplayerServiceRecordAdditional Additional { get; set; }
}

public class MultiplayerServiceRecordAdditional
{
    [JsonProperty("gamertag")]
    public string Gamertag { get; set; }
    [JsonProperty("experience")]
    public string Experience { get; set; }
    [JsonProperty("playlist")]
    public string Playlist { get; set; }
}

public class MultiplayerServiceRecordData
{
    [JsonProperty("core")]
    public MultiplayerServiceRecordCore Core { get; set; }
    [JsonProperty("matches_played")]
    public int MatchesPlayed { get; set; }
    [JsonProperty("time_played")]
    public MultiplayerServiceRecordTimePlayed TimePlayed { get; set; }
    [JsonProperty("win_rate")]
    public decimal WinRate { get; set; }
}

public class MultiplayerServiceRecordTimePlayed
{
    [JsonProperty("seconds")]
    public long Seconds { get; set; }
    [JsonProperty("human")]
    public string Human { get; set; }
}

public class MultiplayerServiceRecordCore
{
    [JsonProperty("summary")]
    public MultiplayerServiceRecordSummary Summary { get; set; }
    [JsonProperty("damage")]
    public MultiplayerServiceRecordDamage Damage { get; set; }
    [JsonProperty("shots")]
    public MultiplayerServiceRecordShots Shots { get; set; }
    [JsonProperty("breakdowns")]
    public MultiplayerServiceRecordBreakdowns Breakdowns { get; set; }
    [JsonProperty("kda")]
    public decimal KillDeathAssistRatio { get; set; }
    [JsonProperty("kdr")]
    public decimal KillDeathRatio { get; set; }
    [JsonProperty("total_score")]
    public long TotalScore { get; set; }
}

public class MultiplayerServiceRecordBreakdowns
{
    [JsonProperty("kills")]
    public MultiplayerServiceRecordBreakdownKills Kills { get; set; }
    [JsonProperty("assists")]
    public MultiplayerServiceRecordBreakdownAssists Assists { get; set; }
    [JsonProperty("matches")]
    public MultiplayerServiceRecordBreakdownMatches Matches { get; set; }
}

public class MultiplayerServiceRecordBreakdownMatches
{
    [JsonProperty("wins")]
    public long Wins { get; set; }
    [JsonProperty("losses")]
    public long Losses { get; set; }
    [JsonProperty("left")]
    public long Left { get; set; }
    [JsonProperty("draws")]
    public long Draws { get; set; }
}

public class MultiplayerServiceRecordBreakdownAssists
{
    [JsonProperty("emp")]
    public long Emp { get; set; }
    [JsonProperty("driver")]
    public long Driver { get; set; }
    [JsonProperty("callouts")]
    public long Callouts { get; set; }
}

public class MultiplayerServiceRecordBreakdownKills
{
    [JsonProperty("melee")]
    public long Melee { get; set; }
    [JsonProperty("grenades")]
    public long Grenades { get; set; }
    [JsonProperty("headshots")]
    public long Headshots { get; set; }
    [JsonProperty("power_weapons")]
    public long PowerWeapons { get; set; }
}

public class MultiplayerServiceRecordShots
{
    [JsonProperty("fired")]
    public long Fired { get; set; }
    [JsonProperty("landed")]
    public long Landed { get; set; }
    [JsonProperty("missed")]
    public long Missed { get; set; }
    [JsonProperty("accuracy")]
    public decimal Accuracy { get; set; }
}

public class MultiplayerServiceRecordSummary
{
    [JsonProperty("kills")]
    public int Kills { get; set; }
    [JsonProperty("deaths")]
    public int Deaths { get; set; }
    [JsonProperty("assists")]
    public int Assists { get; set; }
    [JsonProperty("betrayals")]//number
    public int Betrayals { get; set; }
    [JsonProperty("suicides")]//number
    public int Suicides { get; set; }
    [JsonProperty("vehicles")]//object
    public VehicleServiceRecordStats Vehicles { get; set; }
    [JsonProperty("medals")]//number
    public int Medals { get; set; }
}

public class VehicleServiceRecordStats
{
    [JsonProperty("destroys")]
    public int Destroys { get; set; }
    [JsonProperty("hijacks")]
    public int Hijacks { get; set; }
}

public class MultiplayerServiceRecordDamage
{
    [JsonProperty("taken")]
    public long Taken { get; set; }
    [JsonProperty("dealt")]
    public long Dealt { get; set; }
    [JsonProperty("average")]
    public long Average { get; set; }
}

public class MultiplayerServiceRecordRequest
{
    [JsonProperty("gamertag")]
    public string Gamertag { get; set; }
    [JsonProperty("filter")]
    public string Filter { get; set; }
}
