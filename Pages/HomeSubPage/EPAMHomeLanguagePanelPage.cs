using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.HomeSubPage
{
    public class EPAMHomeLanguagePanelPage : EPAMHomePage
    {
        public EPAMHomeLanguagePanelPage(IWebDriver driver) : base(driver)
        {
        }

        public EPAMHomeLanguagePanelPage GetTheSelectedLanguage(out string selectedLanguage)
        {
            selectedLanguage = GetText(By.XPath("//li[@class= 'location-selector__item']/a[contains(@class, 'active')]"));
            return this;
        }


    }
}
