﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nexmo.Api.Voice.Nccos
{
    public class RecordAction : NccoAction
    {
        public enum AudioFormat
        {
            mp3=1,
            wav=2,
            ogg=3
        }

        [JsonProperty("format")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AudioFormat Format { get; set; }

        [JsonProperty("split")]
        public string Split { get; set; }

        [JsonProperty("channels")]
        public uint Channels { get; set; }

        [JsonProperty("endOnSilence")]
        public string EndOnSilence { get; set; }

        [JsonProperty("endOnKey")]
        public string EndOnKey { get; set; }

        [JsonProperty("timeOut")]
        public string TimeOut { get; set; }

        [JsonProperty("beepStart")]
        public string BeepStart { get; set; }

        [JsonProperty("eventUrl")]
        public string[] EventUrl { get; set; }

        [JsonProperty("eventMethod")]
        public string EventMethod { get; set; }

        public RecordAction()
        {
            Action = ActionType.record;

        }
    }
}
