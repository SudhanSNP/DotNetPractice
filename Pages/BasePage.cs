using Helpers.Actions;
using OpenQA.Selenium;

namespace Pages
{
    public class BasePage : DriverActions
    {
        public BasePage(IWebDriver driver) : base(driver)
        {
        }
    }
}
