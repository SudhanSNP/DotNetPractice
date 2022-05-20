using Helpers.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Tests.BDD.StepDefinitions
{
    [Binding]
    public class EPAMSearchTestStepDefinition
    {
        private IWebDriver driver;
        private BaseDriver WebDriver;

        [Given(@"I have entered the EPAM home page")]
        public void GivenIHaveEnteredTheEPAMHomePage()
        {
            WebDriver = new BaseDriver()
                .SetDriver();

            driver = WebDriver.GetDriver();
            WebDriver.MaximizeDriver();
            WebDriver.NavigateURL("https://www.epam.com/");
        }

        [Given(@"I have navigated to the Search panel")]
        public void GivenIHaveNavigatedToTheSearchPanel()
        {
            new EPAMHomePage(driver)
                .GetPresenceOfSearch(out bool isPresent)
                .ClickSearch();
        }

        [When(@"I entered the SkillSet to search as (.*)")]
        public void WhenIEnteredTheSkillSetToSearchAsAutomation(string skill)
        {
            new EPAMHomePage(driver)
                .WithInSearchPanel()
                .EnterSearchText(skill)
                .ClickFind();
        }

        [Then(@"The record message of the search result should match the (.*)")]
        public void ThenTheRecordMessageOfTheSearchResultShouldMatchThe(int count)
        {
            new EPAMSearchPage(driver)
                .GetResultCount(out string resultCount);

            Assert.That(Int32.Parse(resultCount.Split(' ')[0]), Is.EqualTo(count));
        }


        [Then(@"Close the browser")]
        public void ThenCloseTheBrowser()
        {
            WebDriver.CloseDriver();
        }


    }
}
