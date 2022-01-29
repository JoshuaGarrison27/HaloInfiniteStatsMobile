using Newtonsoft.Json;
using System.Collections.Generic;

namespace HaloInfiniteMobileApp.Models
{
    public class HaloMedals
    {
        [JsonProperty("data")]
        public IEnumerable<Medal> Medals { get; set; }
    }
}