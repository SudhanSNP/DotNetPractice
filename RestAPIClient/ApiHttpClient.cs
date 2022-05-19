using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace RestAPIClient
{
    public class ApiHttpClient
    {
        protected HttpClient client;
        protected HttpResponseMessage response;
        protected HttpRequestMessage request;
        protected string baseUrl;
        public Dictionary<string, string> queryParam;

        public ApiHttpClient(string url)
        {
            this.baseUrl = url;
            client = new HttpClient();
        }

        public HttpRequestMessage GetApiRequest(RequestType type)
        {
            switch (type)
            {
                case RequestType.Get:
                    request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
                    break;
                case RequestType.Post:
                    request = new HttpRequestMessage(HttpMethod.Post, baseUrl);
                    break;
                case RequestType.Put:
                    request = new HttpRequestMessage(HttpMethod.Put, baseUrl);
                    break;
                case RequestType.Delete:
                    request = new HttpRequestMessage(HttpMethod.Delete, baseUrl);
                    break;
                default:
                    throw new ArgumentException("Enter a valid Request type");
            }
            return request;
        }

        public async Task<T> GetAsyncRequest<T>()
        {
            if (queryParam != null && queryParam.Count >= 1)
            {
                baseUrl = QueryHelpers.AddQueryString(baseUrl, queryParam);
            }

            request = GetApiRequest(RequestType.Get);
            request.Headers.Add("Accept", "application/json");

            response = await client.GetAsync(baseUrl);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())
                : throw new Exception($"Respone from '{baseUrl}' is not successful");
        }

        public async Task<T> CreateAsyncRequest<T>(T modal)
        {
            if (queryParam != null && queryParam.Count >= 1)
            {
                baseUrl = QueryHelpers.AddQueryString(baseUrl, queryParam);
            }

            request = GetApiRequest(RequestType.Post);
            request.Headers.Add("Accept", "application/json");
            request.Content = JsonContent.Create(modal);

            response = await client.PostAsync(baseUrl, request.Content);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())
                : throw new Exception($"Respone from '{baseUrl}' is not successful");
        }

        public async Task<T> UpdateAsyncRequest<T>(T modal, string id)
        {
            if (queryParam != null && queryParam.Count >= 1)
            {
                baseUrl = QueryHelpers.AddQueryString(baseUrl, queryParam);
            }
            if (id != null)
                baseUrl = baseUrl + $"/{id}";

            request = GetApiRequest(RequestType.Put);
            request.Headers.Add("Accept", "application/json");
            request.Content = JsonContent.Create(modal);

            response = await client.PutAsync(baseUrl, request.Content);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())
                : throw new Exception($"Respone from '{baseUrl}' is not successful");
        }

        public async Task<HttpStatusCode> DeleteAsyncRequest(string id)
        {
            if (id != null)
                baseUrl = baseUrl + $"/{id}";

            request = GetApiRequest(RequestType.Delete);

            response = await client.SendAsync(request);
            return response.StatusCode;
        }
    }
}
