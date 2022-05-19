using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace RestAPIClient
{
    public class ApiClient
    {
        protected RestClient apiClient;
        protected RestRequest apiRequest;
        protected RestResponse apiResponse;
        protected string baseUrl;
        public Dictionary<string, string> queryParam;

        public ApiClient(string url)
        {
            this.baseUrl = url;
            apiClient = new RestClient(url);
        }
        public RestRequest GetApiRequest(RequestType type)
        {
            switch(type)
            {
                case RequestType.Get:
                    apiRequest = new RestRequest(baseUrl, Method.Get);
                    break;
                case RequestType.Post:
                    apiRequest = new RestRequest(baseUrl, Method.Post);
                    break;
                case RequestType.Put:
                    apiRequest = new RestRequest(baseUrl, Method.Put);
                    break;
                case RequestType.Delete:
                    apiRequest = new RestRequest(baseUrl, Method.Delete);
                    break;
                default:
                    throw new ArgumentException("Enter a valid Request type");
            }
            return apiRequest;
        }

        public async Task<T> GetAsyncRequest<T>()
        {
            apiRequest = GetApiRequest(RequestType.Get)
                .AddHeader("Accept", "application/json");
            if (queryParam != null && queryParam.Count >= 1)
            {
                foreach(KeyValuePair<string, string> param in queryParam)
                    apiRequest.AddQueryParameter(param.Key, param.Value);
            }
            apiResponse = await apiClient.GetAsync(apiRequest);
            return apiResponse.IsSuccessful ? JsonConvert.DeserializeObject<T>(apiResponse.Content) 
                : throw new Exception($"Respone from '{baseUrl}' is not successful");
        }

        public async Task<T> CreateAsyncRequest<T>(T modal)
        {
            apiRequest = GetApiRequest(RequestType.Post)
                .AddHeader("Content-Type", "application/json")
                .AddBody(modal);
            apiResponse = await apiClient.PostAsync(apiRequest);
            return apiResponse.IsSuccessful ? JsonConvert.DeserializeObject<T>(apiResponse.Content)
                : throw new Exception($"Respone from '{baseUrl}' is not successful");
        }

        public async Task<T> UpdateAsyncRequest<T>(T modal, string id)
        {
            apiRequest = GetApiRequest(RequestType.Put)
                .AddUrlSegment("Id", id)
                .AddHeader("Content-Type", "application/json")
                .AddBody(modal);
            apiResponse = await apiClient.PutAsync(apiRequest);
            return apiResponse.IsSuccessful ? JsonConvert.DeserializeObject<T>(apiResponse.Content)
                : throw new Exception($"Respone from '{baseUrl}' is not successful");
        }

        public async Task<HttpStatusCode> DeleteAsyncRequest(string id)
        {
            apiRequest = GetApiRequest(RequestType.Delete)
                .AddUrlSegment("Id", id);
            
            apiResponse = await apiClient.DeleteAsync(apiRequest);
            return apiResponse.StatusCode;
        }
    }
}