using OpenQA.Selenium;
using Pages.HomeSubPage;

namespace Pages
{
    public class EPAMHomePage : BasePage
    {
        public EPAMHomePage(IWebDriver driver) : base(driver)
        {
        }

        public EPAMHomeSearchPanelPage WithInSearchPanel() => new EPAMHomeSearchPanelPage(driver);
        public EPAMHomeLanguagePanelPage WithInLanguagePanel() => new EPAMHomeLanguagePanelPage(driver);

        public EPAMHomePage ClickSearch()
        {
            ClickElement(By.XPath("//button[contains(@class, 'header-search__button')]"));
            return this;
        }

        public EPAMHomePage GetPresenceOfSearch(out bool isPresent)
        {
            isPresent = GetPresenceOfElement(By.XPath("//button[contains(@class, 'header-search__button')]"));
            return this;
        }

        public EPAMHomePage ClickLanguage()
        {
            ClickElement(By.XPath("//button[contains(@class, 'location-selector__button')]"));
            return this;
        }
    }
}