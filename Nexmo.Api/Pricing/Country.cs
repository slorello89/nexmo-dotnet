using Newtonsoft.Json;

namespace Nexmo.Api.Pricing
{
    public class Country
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }
        
        [JsonProperty("countryDisplayName")]
        public string CountryDisplayName { get; set; }
        
        [JsonProperty("currency")]
        public string Currency { get; set; }
        
        [JsonProperty("defaultPrice")]
        public string DefaultPrice { get; set; }
        
        [JsonProperty("dialingPrefix")]
        public string DialingPrefix { get; set; }
        
        [JsonProperty("networks")] 
        public Network[] Networks { get; set; }
    }
}