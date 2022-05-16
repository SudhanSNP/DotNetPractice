using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Helpers.Drivers
{
    public class BaseDriver : IDriver
    {
        private IWebDriver driver;
        private static string Driver_Type = DriverType.Chrome.ToString();

        public BaseDriver()
        {
        }

        public BaseDriver SetDriver()
        {
            switch(Driver_Type)
            {
                case "Chrome": 
                    driver = new ChromeDriver();
                    break;
                case null:
                    Console.WriteLine("Enter the valid browser");
                    break;
            }
            return this;
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void MaximizeDriver()
        {
           driver.Manage().Window.Maximize();
        }

        public void MinimizeDriver()
        {
            driver.Manage().Window.Minimize();
        }

        public void NavigateURL(string url)
        { 
            driver.Navigate().GoToUrl(url);
        }

        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
