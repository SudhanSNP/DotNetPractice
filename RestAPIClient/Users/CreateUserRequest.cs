using RestAPIClient.Users.Modal;

namespace RestAPIClient.Users
{
    public class CreateUserRequest
    {
        private string requestUrl = "https://reqres.in/api/users";
        private ApiClient apiClient;
        private ApiHttpClient client;

        public CreateUserRequest()
        {
            apiClient = new ApiClient(requestUrl);
            client = new ApiHttpClient(requestUrl);
        }

        public async Task<CreateUser> CreateUserData(CreateUser user, bool isHttpClient = false)
        {
            var response = (!isHttpClient) ? await apiClient.CreateAsyncRequest<CreateUser>(user) 
                : await client.CreateAsyncRequest<CreateUser>(user);
            return response;
        }

        public async Task<CreateUser> UpdateUserData(CreateUser user, string userId, bool isHttpClient = false)
        {
            var response = (!isHttpClient) ? await apiClient.UpdateAsyncRequest<CreateUser>(user, userId)
                : await client.UpdateAsyncRequest<CreateUser>(user, userId);
            return response;
        }
    }
}
