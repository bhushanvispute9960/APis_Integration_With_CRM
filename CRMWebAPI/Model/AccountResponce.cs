using Newtonsoft.Json;

namespace CRMWebAPI.Model
{
    public class AccountResponse
    {
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }

        [JsonProperty("value")]
        public List<Account> Accounts { get; set; }
    }
}
