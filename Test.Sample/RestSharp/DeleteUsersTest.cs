using NUnit.Framework;
using RestAPIClient.Users;
using RestAPIClient.Users.Modal;
using System.Net;

namespace Test.Sample.RestSharp
{
    [TestFixture]
    public class DeleteUsersTest
    {
        [Test]
        public async Task DeleteUserTest()
        {
            var User = new CreateUser { Name = "Sudhan", Job = "QA Automation" };
            User = await new CreateUserRequest()
                .CreateUserData(User);

            var status = await new DeleteUsersRequest()
                    .RemoveUserDataList(User.Id.ToString());

            Assert.AreEqual(HttpStatusCode.NoContent, status);
        }
    }
}
