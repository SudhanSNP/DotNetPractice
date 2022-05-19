using RestAPIClient.Users.Modal;

namespace RestAPIClient.Users
{
    public class GetUsersRequest
    {
        private string requestUrl = "https://reqres.in/api/users";
        private ApiClient apiClient;
        private ApiHttpClient client;

        public GetUsersRequest(Dictionary<string,string> queryParam = null)
        {
            apiClient = new ApiClient(requestUrl);
            client = new ApiHttpClient(requestUrl);
            apiClient.queryParam = queryParam;
            client.queryParam = queryParam;
        }

        public async Task<UsersData> GetUsersDataList(bool isHttpClient = false)
        {
            var response = (!isHttpClient) ? await apiClient.GetAsyncRequest<UsersData>() 
                : await client.GetAsyncRequest<UsersData>();
            return response;
        }
    }
}
