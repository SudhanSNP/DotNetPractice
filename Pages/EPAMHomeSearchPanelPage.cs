using OpenQA.Selenium;

namespace Pages
{
    public class EPAMHomeSearchPanelPage : BasePage
    {
        public EPAMHomeSearchPanelPage(IWebDriver driver) : base(driver)
        {
        }

        public EPAMHomeSearchPanelPage EnterSearchText(string search)
        {
            SendText(By.Id("new_form_search"), search);
            return this;
        }

        public EPAMSearchPage ClickFind()
        {
            ClickElement(By.CssSelector(".header-search__submit"));
            return new EPAMSearchPage(driver);
        }
    }
}
