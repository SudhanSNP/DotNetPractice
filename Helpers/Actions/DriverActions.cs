using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Helpers.Actions
{
    public class DriverActions
    {
        public IWebDriver driver { get; set; }

        public DriverActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(By selector)
        {
            WaitUntilElementDisplayed(selector).Click();
        }

        public string GetText(By selector)
        {
            return WaitUntilElementDisplayed(selector).Text;
        }

        protected virtual bool GetPresenceOfElement(By selector)
        {
            return driver.FindElement(selector).Displayed;
        }

        public void GetText(By selector, out List<string> list)
        {
            WaitUntilElementDisplayed(selector);
            list = driver.FindElements(selector)
                .Select(e => e.Text).ToList();
        }

        public void SendText(By selector, string text)
        {
            WaitUntilElementDisplayed(selector).SendKeys(text);
        }

        public void ClearText(By selector)
        {
            WaitUntilElementDisplayed(selector).Clear();
        }

        protected virtual IWebElement WaitUntilElementDisplayed(By selector)
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, 5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }
    }
}
