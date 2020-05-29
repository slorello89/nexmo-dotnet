using Newtonsoft.Json;

namespace Nexmo.Api
{
#if DOXYGEN_SHOULD_SKIP_THIS
    public class ResponseBase
    {
        [JsonProperty("error-code")]
        public string ErrorCode { get; set; }
        [JsonProperty("error-code-label")]
        public string ErrorCodeLabel { get; set; }
    }
#endif
}
