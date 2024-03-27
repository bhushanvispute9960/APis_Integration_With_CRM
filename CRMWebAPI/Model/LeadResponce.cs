using Newtonsoft.Json;

namespace CRMWebAPI.Model
{
    public class LeadResponce
    {
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }

        [JsonProperty("value")]
        public List<Lead> Leads { get; set; }
    }
}
