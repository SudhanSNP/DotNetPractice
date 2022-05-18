using RestAPIClient.Users.Modal;

namespace RestAPIClient.Users
{
    public class GetUsersRequest
    {
        private string requestUrl = "https://reqres.in/api/users";
        private ApiClient apiClient;

        public GetUsersRequest(Dictionary<string,string> queryParam = null)
        {
            apiClient = new ApiClient(requestUrl);
            apiClient.queryParam = queryParam;
        }

        public async Task<UsersData> GetUsersDataList()
        {
            var response = await apiClient.GetAsyncRequest<UsersData>();
            return response;
        }
    }
}
