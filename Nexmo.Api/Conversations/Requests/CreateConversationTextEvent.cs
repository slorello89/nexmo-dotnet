using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Nexmo.Api.Conversations.Request
{
    public class CreateConversationTextEvent : CreateEventBase
    {
        [JsonProperty("type")]
        public string Type { get; private set; } = "Text";

        [JsonProperty("body")]
        public CreateConversationTextEventBody Body { get; set; }

        public class CreateConversationTextEventBody
        {
            [JsonProperty("text")]
            public string Text { get; set; }
        }
    }
}
