using System.Collections.Generic;
using Newtonsoft.Json;

namespace HCP_Assessment.Models.HCP
{

    public class HcpUsers
    {
        [JsonProperty("userid")]
        public string Userid { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("outputtype")]
        public string Outputtype { get; set; }

        [JsonProperty("users")]
        public List<HCPUser> Users { get; set; }
    }
}
