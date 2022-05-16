using OpenQA.Selenium;

namespace Pages
{
    public class EPAMHomePage : BasePage
    {
        public EPAMHomePage(IWebDriver driver) : base(driver)
        {
        }

        public EPAMHomeSearchPanelPage WithInSearchPanel() => new EPAMHomeSearchPanelPage(driver);

        public EPAMHomePage ClickSearch()
        {
            ClickElement(By.XPath("//button[contains(@class, 'header-search__button')]"));
            return this;
        }


    }
}