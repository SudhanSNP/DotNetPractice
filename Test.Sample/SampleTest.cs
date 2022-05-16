using NUnit.Framework;
using Helpers.Drivers;
using OpenQA.Selenium;
using Pages;

namespace Test.Sample
{
    [TestFixture]
    public class SampleTest
    {
        private IWebDriver driver;
        private BaseDriver WebDriver;

        [SetUp]
        public void SetUp() 
        {
            WebDriver = new BaseDriver(driver);
            driver = WebDriver.SetDriver();
            WebDriver.NavigateURL("https://www.epam.com/");
        }

        [Test]
        public void EPAMSearchTest()
        {
            var page = new EPAMHomePage(driver)
                .ClickSearch()
                .WithInSearchPanel()
                .EnterSearchText("Automation")
                .ClickFind()
                .GetResultCount(out string resultCount);

            Assert.That(resultCount, Is.EqualTo("386 RESULTS FOR " + '"' +"AUTOMATION" + '"'));

            page.ClearSearch()
                .ClickSearchBox()
                .GetFrequentSearchList(out List<string> searchList);

            Assert.AreEqual(new List<string> 
            { 
                "Blockchain", "Cloud", "DevOps", "Open Source", "RPA", "Automation", "Digital Risk Management", "Contact" 
            }, 
            searchList);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }

    }
}