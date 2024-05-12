using OpenQA.Selenium;
using RPFramework.Core.Driver;

namespace RPFramework.Business.Pages
{
    public interface IHomePage
    {
        void ClickLaunches();
        void LaunchesDisplayed();
    }

    public class HomePage : IHomePage
    {
        private readonly IDriverWait _idriverWait;

        public HomePage(IDriverWait idriverWait)
        {
            _idriverWait = idriverWait;
        }

        private IWebElement launchesLink => _idriverWait.FindElement(By.CssSelector("a[href='#default_personal/launches'], a[href='#superadmin_personal/launches'], a[href='#automation/launches']"));

        public void ClickLaunches()
        {
            launchesLink.Click();
        }

        public void LaunchesDisplayed()
        {
            try
            {
                bool isDisplayed = launchesLink.Displayed;
            }
            catch
            {
                Exception e;
            }

        }
    }
}
