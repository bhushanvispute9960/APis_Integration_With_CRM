using Newtonsoft.Json;

namespace CRMWebAPI.Model
{
    public class Account
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("accountid")]
        public string AccountId { get; set; }
    }

}
