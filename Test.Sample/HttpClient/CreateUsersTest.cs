using NUnit.Framework;
using RestAPIClient.Users;
using RestAPIClient.Users.Modal;

namespace Test.Sample.HttpClient
{
    [TestFixture]
    public class CreateUsersTest
    {
        [Test]
        public async Task CreateUserDataTest()
        {
            var User = new CreateUser { Name = "Sudhan", Job = "QA Automation" };
            User = await new CreateUserRequest()
                .CreateUserData(User, true);

            Assert.Multiple(() => {
                Assert.AreEqual("Sudhan", User.Name);
                Assert.AreEqual("QA Automation", User.Job);
                Assert.True(User.CreatedAt.Contains(DateTime.Now.ToString("yyyy-MM-dd")));
            });

            var modifiedUser = new CreateUser { Name = "Sudhan Sankaranarayana Pillai", Job = "QA Automation" };

            User = await new CreateUserRequest()
                .UpdateUserData(modifiedUser, User.Id.ToString(), true);

            Assert.Multiple(() => {
                Assert.AreEqual(modifiedUser.Name, User.Name);
                Assert.True(User.UpdatedAt.Contains(DateTime.Now.ToString("yyyy-MM-dd")));
            });
        }
    }
}
