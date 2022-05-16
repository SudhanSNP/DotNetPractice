using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Helpers.Drivers
{
    public class BaseDriver : IDriver
    {
        public IWebDriver driver;

        public BaseDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void MaximizeDriver()
        {
           var window = driver.Manage().Window.Maximize;
        }

        public void MinimizeDriver()
        {
            var window = driver.Manage().Window.Minimize;
        }

        public IWebDriver SetDriver()
        {
            driver = new ChromeDriver();
            return driver;
        }

        public void NavigateURL(string url)
        { 
            driver.Navigate().GoToUrl(url);
        }

        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
