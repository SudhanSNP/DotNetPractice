using RestAPIClient.Users.Modal;

namespace RestAPIClient.Users
{
    public class CreateUserRequest
    {
        private string requestUrl = "https://reqres.in/api/users";
        private ApiClient apiClient;
        public CreateUserRequest()
        {
            apiClient = new ApiClient(requestUrl);
        }

        public async Task<CreateUser> CreateUserData(CreateUser user)
        {
            var response = await apiClient.CreateAsyncRequest<CreateUser>(user);
            return response;
        }

        public async Task<CreateUser> UpdateUserData(CreateUser user, string userId)
        {
            var response = await apiClient.UpdateAsyncRequest<CreateUser>(user, userId);
            return response;
        }
    }
}
