using Newtonsoft.Json;

namespace HaloInfiniteMobileApp.Models
{
    public class CampaignRecord
    {
        [JsonProperty("data")]
        public Campaign Campaign { get; set; }
        [JsonProperty("additional")]
        public AdditionalCampaignProperties Additional { get; set; }
    }

    public class CampaignRequest : ServiceRequestBase
    {
        public CampaignRequest(string gamertag)
        {
            Gamertag = gamertag;
        }

        [JsonProperty("gamertag")]
        public string Gamertag { get; set; }
    }

    public class Campaign
    {
        [JsonProperty("skulls")]
        public int Skulls { get; set; }
        [JsonProperty("fob_secured")]
        public int FobSecured { get; set; }
        [JsonProperty("spartan_cores")]
        public int SpartanCores { get; set; }
        [JsonProperty("mission_completed")]
        public int MissionsCompleted { get; set; }
        [JsonProperty("propaganda_towers_destroyed")]
        public int PropagandaTowersDestroyed { get; set; }
        [JsonProperty("audio_logs")]
        public AudioLogs AudioLogs { get; set; }
        [JsonProperty("difficulty")]
        public CampaignDifficulty Difficulty { get; set; }
        [JsonIgnore]
        public CampaignDefaults Defaults { get; set; } = new CampaignDefaults();
    }

    public class AudioLogs
    {
        [JsonProperty("unsc")]
        public int UNSC { get; set; }
        [JsonProperty("banished")]
        public int Banished { get; set; }
        [JsonProperty("spartans")]
        public int Spartans { get; set; }
        [JsonIgnore]
        public int Total => UNSC + Banished + Spartans;
    }

    public class CampaignDifficulty
    {
        [JsonProperty("highest_completed")]
        public string HighestCompleted { get; set; }
        [JsonProperty("highest_completed_image_url")]
        public string HighestCompletedImageUrl { get; set; }
        [JsonProperty("laso_completed")]
        public bool LasoCompleted { get; set; }
    }

    public class AdditionalCampaignProperties
    {
        public string gamertag { get; set; }
    }

    public class CampaignDefaults
    {
        public int TotalSkulls { get; set; } = 12;
        public int TotalFobSecured { get; set; } = 12;
        public int TotalSpartanCores { get; set; } = 45;
        public int TotalMissions { get; set; } = 14;
        public int TotalPropagandaTowers { get; set; } = 40;
        public int TotalUnscAudioLogs { get; set; } = 37;
        public int TotalBanishedAudioLogs { get; set; } = 28;
        public int TotalSpartanAudioLogs { get; set; } = 39;
        public int TotalAudioLogs => TotalUnscAudioLogs + TotalBanishedAudioLogs + TotalSpartanAudioLogs;
    }
}