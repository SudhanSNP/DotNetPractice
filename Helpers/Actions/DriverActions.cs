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
            WaitUntilElementDisplayed(selector);
            MoveToElement(selector);
            driver.FindElement(selector).Click();
        }

        public string GetText(By selector)
        {
            return WaitUntilElementDisplayed(selector).Text;
        }

        public string GetAttributes(By selector, string attribute)
        {
            return WaitUntilElementDisplayed(selector).GetAttribute(attribute);
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

        public void GetAttributes(By selector, string attribute, out List<string> list)
        {
            WaitUntilElementDisplayed(selector);
            list = driver.FindElements(selector)
                .Select(e => e.GetAttribute(attribute)).ToList();
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

        protected void MoveToElement(By selector)
        {
            OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.MoveToElement(driver.FindElement(selector));
            actions.Perform();
        }
    }
}
