using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Nexmo.Api.Conversations.Request;
using Nexmo.Api.Conversations.Reponses;
using Nexmo.Api.Request;
using Newtonsoft.Json;

namespace Nexmo.Api
{
    public class User
    {
        public const string CONVERSATION_API_ENDPOINT = "/beta2/users";
        public static UserResponse CreateUser(CreateUserRequest request, Credentials creds = null)
        {
            var response = VersionedApiRequest.DoRequest("POST", ApiRequest.GetBaseUriFor(typeof(User), CONVERSATION_API_ENDPOINT), request, creds);
            return JsonConvert.DeserializeObject<UserResponse>(response.JsonResponse);
        }

        public static UserResponse GetUser(string userId, Credentials credentials = null)
        {
            var response = ApiRequest.DoRequest(ApiRequest.GetBaseUriFor(typeof(User), $"{CONVERSATION_API_ENDPOINT}/{userId}"), credentials);
            return JsonConvert.DeserializeObject<UserResponse>(response);
        }

        public static List<UserResponse> GetUsers(Credentials credentials = null)
        {
            var response = ApiRequest.DoRequest(ApiRequest.GetBaseUriFor(typeof(User), $"{CONVERSATION_API_ENDPOINT}"), credentials);
            return JsonConvert.DeserializeObject<List<UserResponse>>(response);
        }

        public static UserResponse UpdateUser(string userId, CreateUserRequest request, Credentials creds = null)
        {
            var response = VersionedApiRequest.DoRequest("PUT", ApiRequest.GetBaseUriFor(typeof(User), $"{CONVERSATION_API_ENDPOINT}/{userId}"), request, creds);
            return JsonConvert.DeserializeObject<UserResponse>(response.JsonResponse);
        }

        public static HttpStatusCode DeleteUser(string userId, Credentials creds = null)
        {
            var response = VersionedApiRequest.DoRequest("DELETE", ApiRequest.GetBaseUriFor(typeof(User), $"{CONVERSATION_API_ENDPOINT}/{userId}"), null, creds);
            return response.Status;
        }
    }
}
