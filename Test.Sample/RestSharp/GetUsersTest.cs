using NUnit.Framework;
using RestAPIClient.Users;

namespace Test.Sample.RestSharp
{
    [TestFixture]
    public class GetUsersTest
    {
        [Test]
        public async Task UserTest()
        {
            List<string> expectedNames = new List<string> { "George", "Janet", "Emma", "Eve", "Charles", "Tracey" };
            var Users = await new GetUsersRequest()
                .GetUsersDataList();

            List<string> actualNames = Users.Data.Select(usr => usr.FirstName).ToList();

            Assert.AreEqual(expectedNames, actualNames);

            expectedNames = new List<string> { "Michael", "Lindsay", "Tobias", "Byron", "George", "Rachel" };

            Users = await new GetUsersRequest(new Dictionary<string, string> { { "page", "2" } })
                .GetUsersDataList();

            actualNames = Users.Data.Select(usr => usr.FirstName).ToList();

            Assert.AreEqual(expectedNames, actualNames);
        }
    }
}
