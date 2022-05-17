using NUnit.Framework;
using Helpers.Drivers;
using OpenQA.Selenium;
using Pages;

namespace Test.Sample
{
    [TestFixture]
    public class EPAMSearchPageTest
    {
        private IWebDriver driver;
        private BaseDriver WebDriver;

        [SetUp]
        public void SetUp() 
        {
            WebDriver = new BaseDriver()
                .SetDriver();
            
            driver = WebDriver.GetDriver();
            WebDriver.MaximizeDriver();
            WebDriver.NavigateURL("https://www.epam.com/");
        }

        [Test]
        public void EPAMSearchTest()
        {
            var page = new EPAMHomePage(driver)
                .GetPresenceOfSearch(out bool isPresent)
                .ClickSearch()
                .WithInSearchPanel()
                .GetPositionOfFrequentSearchText("RPA", out int position)
                .EnterSearchText("Automation")
                .ClickFind()
                .GetResultCount(out string resultCount);

            Assert.IsTrue(isPresent);
            Assert.That(resultCount, Is.EqualTo("385 RESULTS FOR " + '"' +"AUTOMATION" + '"'));
            Assert.That(position, Is.EqualTo(5));
            Assert.That(Int32.Parse(resultCount.Split(' ')[0]), Is.EqualTo(385));

            Console.WriteLine($"The test is currently in {page.GetType()}");
            Assert.IsTrue(typeof(BasePage).IsInstanceOfType(page));

            page.ClearSearch()
                .ClickSearchBox()
                .GetFrequentSearchList(out List<string> searchList);

            var expectedSearchList = new List<string>
            {
                "Blockchain", "Cloud", "DevOps", "Open Source", "RPA", "Automation", "Digital Risk Management", "Contact"
            };

            Assert.Multiple(() => {
                int i = 0;
                foreach(var str in expectedSearchList)
                {
                    Assert.IsTrue(searchList[i].Equals(str));
                    i++;
                }
            });
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }

    }
}