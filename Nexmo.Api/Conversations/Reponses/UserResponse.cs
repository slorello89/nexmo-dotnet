using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexmo.Api.Conversations.Reponses
{
    public class UserResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("properties")]
        public UserProperties Properties { get; set; }

        [JsonProperty("user_links")]
        public Links UserLinks { get; set; }

        public class UserProperties
        {
            [JsonProperty("custom_data")]
            public string CustomData { get; set; }
        }
        
        public class Links
        {
            [JsonProperty("self")]
            public LinkContainer Self { get; set; }
            public class LinkContainer
            {
                [JsonProperty("href")]
                public string Href { get; set; }
            }
        }
    }
}
