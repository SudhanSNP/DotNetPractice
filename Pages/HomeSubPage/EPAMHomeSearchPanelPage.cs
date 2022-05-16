using OpenQA.Selenium;

namespace Pages.HomeSubPage
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

        public EPAMHomePage GoToHome()
        {
            ClickElement(By.ClassName("header__logo"));
            return new EPAMHomePage(driver);
        }

        public EPAMSearchPage ClickFind()
        {
            ClickElement(By.CssSelector(".header-search__submit"));
            return new EPAMSearchPage(driver);
        }

        public EPAMHomeSearchPanelPage GetPositionOfFrequentSearchText(string search, out int position)
        {
            GetText(By.CssSelector(".frequent-searches__item"), out List<string> searchList);
            // position = searchList.IndexOf(search);
            int i = 1;
            position = 0;
            foreach(var s in searchList)
            {
                if(s == search) 
                {
                    position = i;
                    break;
                }
                else
                {
                    i++;
                    continue;
                }
            }
            return this;
        }
    }
}
