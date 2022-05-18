using System.Net;

namespace RestAPIClient.Users
{
    public class DeleteUsersRequest
    {
        private string requestUrl = "https://reqres.in/api/users";
        private ApiClient apiClient;

        public DeleteUsersRequest()
        {
            apiClient = new ApiClient(requestUrl);
        }

        public async Task<HttpStatusCode> RemoveUserDataList(string id)
        {
            var response = await apiClient.DeleteAsyncRequest(id);
            return response.StatusCode;
        }
    }
}
