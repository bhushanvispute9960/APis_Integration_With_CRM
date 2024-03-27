using Newtonsoft.Json;

namespace CRMWebAPI.Model
{
    public class Lead
    {
        [JsonProperty("emailaddress1")]
        public string EmailAddress1 { get; set; }

        [JsonProperty("address1_composite")]
        public string Address1Composite { get; set; }

        [JsonProperty("companyname")]
        public string CompanyName { get; set; }

        [JsonProperty("jobtitle")]
        public string JobTitle { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}
