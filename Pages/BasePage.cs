using Helpers.Actions;
using Helpers.Exceptions;
using Helpers.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class BasePage : DriverActions
    {
        public BasePage(IWebDriver driver) : base(driver)
        {
        }

        protected override IWebElement WaitUntilElementDisplayed(By selector)
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, 5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(selector));
        }

        protected override bool GetPresenceOfElement(By selector)
        {
            bool a = false;
            try
            {
                driver.FindElement(selector);
                a = true;
            }
            catch(NoSuchElementException exp)
            {
                Log.PrintLog(new ErrorLog().LogMessage($"Unable to find the element '{selector}' getting following exception : {exp.Message}"));
                a = false;
            }
            finally
            {
                if (a)
                    Log.PrintLog(new InfoLog().LogMessage($"Element '{selector}' is Present"));
                else
                    throw new ElementNotFoundException("Enter a valid Element");
            }
            return a;
        }
    }
}
