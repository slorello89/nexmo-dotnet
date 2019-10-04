using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexmo.Api.Request
{
    public class CreateConversationCustomEvent : CreateEventBase
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public CreateCustomEventBody Body { get; set; }
        public class CreateCustomEventBody
        {

        }
    }
}
