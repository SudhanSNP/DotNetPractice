using Helpers.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;

namespace Test.Sample
{
    [TestFixture]
    public class EPAMHomePageTest
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
        public void HomePageTest()
        {
            
            new EPAMHomePage(driver)
                .AcceptCookies()
                .GetRegionOffice("Americas", out List<string> americaOffices)
                .ClickRegion("EMEA")
                .GetRegionOffice("EMEA", out List<string> emeaOffices)
                .ClickRegion("APAC")
                .GetRegionOffice("APAC", out List<string> apacOffices);

            var Regions = new List<Region>
            {
                new Region
                {
                    Name = "Americas",
                    Offices = americaOffices,
                },
                new Region
                {
                    Name = "EMEA",
                    Offices = emeaOffices,
                },
                new Region
                {
                    Name = "APAC",
                    Offices = apacOffices,
                }
            };
            
            Regions.Sort();
            Assert.That(Regions.FirstOrDefault().Name.Equals("Americas"));

            CompareRegion reg = new CompareRegion();
            Regions.Sort(reg);
            Assert.That(Regions.FirstOrDefault().Name.Equals("APAC"));

            Console.WriteLine(reg.GetHashCode());
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.CloseDriver();
        }
    }

    public class CompareRegion : IComparer<Region>
    {
        public int Compare(Region? x, Region? y)
        {
            if (x.Offices.Count < y.Offices.Count)
                return 1;
            else if (x.Offices.Count > y.Offices.Count)
                return -1;
            else
                return 0;
        }
    }

    public class Region : IComparable<Region>
    {
        public string Name { get; set; }
        public List<string> Offices { get; set; }
        public int CompareTo(Region other)
        {
            if(this.Offices.Count > other.Offices.Count)
                return 1;
            else if (this.Offices.Count < other.Offices.Count)
                return -1;
            else
                return 0;
        }
    }
}
