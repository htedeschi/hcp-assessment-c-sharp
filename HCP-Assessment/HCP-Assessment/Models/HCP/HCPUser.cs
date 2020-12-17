using Newtonsoft.Json;

namespace HCP_Assessment.Models.HCP
{
    public class HCPUser
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("company_full_address")]
        public string CompanyFullAddress { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
