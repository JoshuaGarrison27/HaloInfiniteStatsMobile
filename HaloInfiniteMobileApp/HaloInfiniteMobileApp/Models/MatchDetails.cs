using System;

namespace HaloInfiniteMobileApp.Models.MatchData;

public class MatchDetails
{
    public Data data { get; set; }
}

public class MatchDetailsRequest
{
    public string id { get; set; }
}

public class Data
{
    public string id { get; set; }
    public Details details { get; set; }
    public Teams teams { get; set; }
    public Player[] players { get; set; }
    public string experience { get; set; }
    public DateTime played_at { get; set; }
    public Duration1 duration { get; set; }
}

public class Details
{
    public Category category { get; set; }
    public Map map { get; set; }
    public Playlist playlist { get; set; }
}

public class Category
{
    public string name { get; set; }
    public Asset asset { get; set; }
}

public class Asset
{
    public string id { get; set; }
    public string version { get; set; }
    public string thumbnail_url { get; set; }
}

public class Map
{
    public string name { get; set; }
    public Asset1 asset { get; set; }
}

public class Asset1
{
    public string id { get; set; }
    public string version { get; set; }
    public string thumbnail_url { get; set; }
}

public class Playlist
{
    public string name { get; set; }
    public Asset2 asset { get; set; }
    public Properties properties { get; set; }
}

public class Asset2
{
    public string id { get; set; }
    public string version { get; set; }
    public string thumbnail_url { get; set; }
}

public class Properties
{
    public object queue { get; set; }
    public object input { get; set; }
    public bool ranked { get; set; }
}

public class Teams
{
    public bool enabled { get; set; }
    public bool scoring { get; set; }
    public Detail[] details { get; set; }
}

public class Detail
{
    public Team team { get; set; }
    public Stats stats { get; set; }
    public int rank { get; set; }
    public string outcome { get; set; }
}

public class Team
{
    public int id { get; set; }
    public string name { get; set; }
    public string emblem_url { get; set; }
}

public class Stats
{
    public Core core { get; set; }
    public Mode mode { get; set; }
}

public class Core
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

public class Summary
{
    public int kills { get; set; }
    public int deaths { get; set; }
    public int assists { get; set; }
    public int betrayals { get; set; }
    public int suicides { get; set; }
    public Vehicles vehicles { get; set; }
    public int medals { get; set; }
}

public class Vehicles
{
    public int destroys { get; set; }
    public int hijacks { get; set; }
}

public class Damage
{
    public int taken { get; set; }
    public int dealt { get; set; }
}

public class Shots
{
    public int fired { get; set; }
    public int landed { get; set; }
    public int missed { get; set; }
    public float accuracy { get; set; }
}

public class Rounds
{
    public int won { get; set; }
    public int lost { get; set; }
    public int tied { get; set; }
}

public class Breakdowns
{
    public Kills kills { get; set; }
    public Assists assists { get; set; }
    public Medal[] medals { get; set; }
}

public class Kills
{
    public int melee { get; set; }
    public int grenades { get; set; }
    public int headshots { get; set; }
    public int power_weapons { get; set; }
}

public class Assists
{
    public int emp { get; set; }
    public int driver { get; set; }
    public int callouts { get; set; }
}

public class Medal
{
    public long id { get; set; }
    public string name { get; set; }
    public int count { get; set; }
    public Image_Urls image_urls { get; set; }
}

public class Image_Urls
{
    public string small { get; set; }
    public string medium { get; set; }
    public string large { get; set; }
}

public class Mode
{
    public Zones zones { get; set; }
}

public class Zones
{
    public int secured { get; set; }
    public int captured { get; set; }
    public Occupation occupation { get; set; }
    public Kills1 kills { get; set; }
}

public class Occupation
{
    public int ticks { get; set; }
    public Duration duration { get; set; }
}

public class Duration
{
    public int seconds { get; set; }
    public string human { get; set; }
}

public class Kills1
{
    public int defensive { get; set; }
    public int offensive { get; set; }
}

public class Duration1
{
    public int seconds { get; set; }
    public string human { get; set; }
}

public class Player
{
    public string gamertag { get; set; }
    public string type { get; set; }
    public Team1 team { get; set; }
    public Stats1 stats { get; set; }
    public int rank { get; set; }
    public string outcome { get; set; }
    public Participation participation { get; set; }
    public Progression progression { get; set; }
}

public class Team1
{
    public int id { get; set; }
    public string name { get; set; }
    public string emblem_url { get; set; }
}

public class Stats1
{
    public Core1 core { get; set; }
    public Mode1 mode { get; set; }
}

public class Core1
{
    public Summary1 summary { get; set; }
    public Damage1 damage { get; set; }
    public Shots1 shots { get; set; }
    public Rounds1 rounds { get; set; }
    public Breakdowns1 breakdowns { get; set; }
    public float kda { get; set; }
    public float kdr { get; set; }
    public int score { get; set; }
}

public class Summary1
{
    public int kills { get; set; }
    public int deaths { get; set; }
    public int assists { get; set; }
    public int betrayals { get; set; }
    public int suicides { get; set; }
    public Vehicles1 vehicles { get; set; }
    public int medals { get; set; }
}

public class Vehicles1
{
    public int destroys { get; set; }
    public int hijacks { get; set; }
}

public class Damage1
{
    public int taken { get; set; }
    public int dealt { get; set; }
}

public class Shots1
{
    public int fired { get; set; }
    public int landed { get; set; }
    public int missed { get; set; }
    public float accuracy { get; set; }
}

public class Rounds1
{
    public int won { get; set; }
    public int lost { get; set; }
    public int tied { get; set; }
}

public class Breakdowns1
{
    public Kills2 kills { get; set; }
    public Assists1 assists { get; set; }
    public Medal1[] medals { get; set; }
}

public class Kills2
{
    public int melee { get; set; }
    public int grenades { get; set; }
    public int headshots { get; set; }
    public int power_weapons { get; set; }
}

public class Assists1
{
    public int emp { get; set; }
    public int driver { get; set; }
    public int callouts { get; set; }
}

public class Medal1
{
    public long id { get; set; }
    public string name { get; set; }
    public int count { get; set; }
    public Image_Urls1 image_urls { get; set; }
}

public class Image_Urls1
{
    public string small { get; set; }
    public string medium { get; set; }
    public string large { get; set; }
}

public class Mode1
{
    public Zones1 zones { get; set; }
}

public class Zones1
{
    public int secured { get; set; }
    public int captured { get; set; }
    public Occupation1 occupation { get; set; }
    public Kills3 kills { get; set; }
}

public class Occupation1
{
    public int ticks { get; set; }
    public Duration2 duration { get; set; }
}

public class Duration2
{
    public int seconds { get; set; }
    public string human { get; set; }
}

public class Kills3
{
    public int defensive { get; set; }
    public int offensive { get; set; }
}

public class Participation
{
    public bool joined_in_progress { get; set; }
    public Presence presence { get; set; }
}

public class Presence
{
    public bool beginning { get; set; }
    public bool completion { get; set; }
}

public class MatchType
{
    public bool matchType { get; set; }
}

public class Progression
{
    public Csr csr { get; set; }
}

public class Csr
{
    public Pre_Match pre_match { get; set; }
    public Post_Match post_match { get; set; }
}

public class Pre_Match
{
    public string tier { get; set; }
    public int value { get; set; }
    public int tier_start { get; set; }
    public int sub_tier { get; set; }
    public string tier_image_url { get; set; }
}

public class Post_Match
{
    public string tier { get; set; }
    public int value { get; set; }
    public int tier_start { get; set; }
    public int sub_tier { get; set; }
    public string tier_image_url { get; set; }
}