using Nexmo.Api.Request;

namespace Nexmo.Api.Verify
{
    public class VerifyClient : IVerifyClient
    {
        public Credentials Credentials { get; set; }

        public VerifyClient(Credentials creds)
        {
            Credentials = creds;
        }
        public VerifyResponse VerifyRequest(VerifyRequest request, Credentials creds = null)
        {
            var response = ApiRequest.DoPostRequestUrlContentFromObject<VerifyResponse>(
                ApiRequest.GetBaseUri(ApiRequest.UriType.Api, "/verify/json"),
                request,
                creds ?? Credentials
            );
            ValidateVerifyResponse(response);
            return response;
        }

        public VerifyCheckResponse VerifyCheck(VerifyCheckRequest request, Credentials creds = null)
        {
            var response = ApiRequest.DoPostRequestUrlContentFromObject<VerifyCheckResponse>(
                ApiRequest.GetBaseUri(ApiRequest.UriType.Api, "/verify/check/json"),
                request,
                creds ?? Credentials
            );
            ValidateVerifyResponse(response);
            return response;
        }

        public VerifySearchResponse VerifySearch(VerifySearchRequest request, Credentials creds = null)
        {
            return ApiRequest.DoGetRequestWithQueryParameters<VerifySearchResponse>(
                ApiRequest.GetBaseUri(ApiRequest.UriType.Api, "/verify/search/json"),
                ApiRequest.AuthType.Query,
                request,
                creds ?? Credentials
            );
        }

        public VerifyControlResponse VerifyControl(VerifyControlRequest request, Credentials creds = null)
        {
            var response = ApiRequest.DoPostRequestUrlContentFromObject<VerifyControlResponse>(
                ApiRequest.GetBaseUri(ApiRequest.UriType.Api, "/verify/control/json"),
                request,
                creds ?? Credentials
            );
            ValidateVerifyResponse(response);
            return response;
        }

        public void ValidateVerifyResponse(VerifyResponseBase response)
        {
            if (response.Status != "0")
            {
                throw new NexmoVerifyResponseException($"Verify Request Failed with status: {response.Status} and Error Text: {response.ErrorText}") { Response = response };
            }
        }
    }
}