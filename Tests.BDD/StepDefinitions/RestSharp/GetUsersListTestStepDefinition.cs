using NUnit.Framework;
using RestAPIClient.Users;
using RestAPIClient.Users.Modal;

namespace Tests.BDD.StepDefinitions.RestSharp
{
    [Binding]
    public class GetUsersListTestStepDefinition
    {
        private GetUsersRequest Request;
        private UsersData Users;
        private List<string> UserNames;

        [Given(@"The API clients are Initialized")]
        public void GivenTheAPIClientsAreInitialized()
        {
            Request = new GetUsersRequest();
        }

        [When(@"The User names are retrieved from the Get API Request")]
        public async Task WhenTheUserNamesAreRetrievedFromTheGetAPIRequest()
        {
            Users = await Request.GetUsersDataList();
            UserNames = Users.Data.Select(usr => usr.FirstName).ToList();
        }

        [Then(@"The following Names should present")]
        public void ThenTheFollowingNamesShouldPresent(Table table)
        {
            var names = table.Rows.Select(t=> t["Name"]).ToList();
            Assert.AreEqual(names, UserNames);
        }

    }
}
