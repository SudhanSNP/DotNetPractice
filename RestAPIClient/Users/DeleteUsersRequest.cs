using System.Net;

namespace RestAPIClient.Users
{
    public class DeleteUsersRequest
    {
        private string requestUrl = "https://reqres.in/api/users";
        private ApiClient apiClient;
        private ApiHttpClient client;

        public DeleteUsersRequest()
        {
            apiClient = new ApiClient(requestUrl);
            client = new ApiHttpClient(requestUrl);
        }

        public async Task<HttpStatusCode> RemoveUserDataList(string id, bool isHttpClient = false)
        {
            var response = (!isHttpClient) ? await apiClient.DeleteAsyncRequest(id)
                : await client.DeleteAsyncRequest(id);
            return response;
        }
    }
}
