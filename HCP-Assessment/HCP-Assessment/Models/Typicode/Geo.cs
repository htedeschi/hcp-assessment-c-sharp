using Newtonsoft.Json;

namespace HCP_Assessment.Models.Typicode
{
    public class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }
    }
}