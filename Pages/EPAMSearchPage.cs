using OpenQA.Selenium;

namespace Pages
{
    public class EPAMSearchPage : BasePage
    {
        public EPAMSearchPage(IWebDriver driver) : base(driver)
        {
        }

        public EPAMSearchPage GetResultCount(out string result)
        {
            result = GetText(By.ClassName("search-results__counter"));
            return this;
        }

        public EPAMSearchPage AcceptCookies()
        {
            ClickElement(By.XPath("//button[text()='Accept All']"));
            return this;
        }

        public EPAMSearchPage ClearSearch()
        {
            ClearText(By.XPath("//form[contains(@class,'search-results__panel')]/div/input"));
            return this;
        }

        public EPAMSearchPage ClickSearchBox()
        {
            ClickElement(By.XPath("//form[contains(@class,'search-results__panel')]/div/input"));
            return this;
        }

        public EPAMSearchPage GetFrequentSearchList(out List<string> searchList)
        {
            GetText(By.XPath("//div[@class='frequent-searches-ui']/ul/li[@class='frequent-searches__item']"), out searchList);
            return this;
        }
    }
}
