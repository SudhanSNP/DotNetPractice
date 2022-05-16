using OpenQA.Selenium;

namespace Helpers.Drivers
{
    public interface IDriver
    {
        public IWebDriver SetDriver();
        public void MaximizeDriver();
        public void MinimizeDriver();
        public void NavigateURL(string url);
        public void CloseDriver();

    }
}
