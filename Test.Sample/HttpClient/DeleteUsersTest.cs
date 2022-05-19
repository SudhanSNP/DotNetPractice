using NUnit.Framework;
using RestAPIClient.Users;
using RestAPIClient.Users.Modal;
using System.Net;

namespace Test.Sample.HttpClient
{
    [TestFixture]
    public class DeleteUsersTest
    {
        [Test]
        public async Task RemoveUserTest()
        {
            var User = new CreateUser { Name = "Sudhan", Job = "QA Automation" };
            User = await new CreateUserRequest()
                .CreateUserData(User, true);

            var status = await new DeleteUsersRequest()
                    .RemoveUserDataList(User.Id.ToString(), true);

            Assert.AreEqual(HttpStatusCode.NoContent, status);
        }
    }
}
