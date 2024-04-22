using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RPFramework.Core.Config;

namespace RPFramework.Core.Driver
{
    public class DriverWait : IDriverWait
    {
        private readonly IDriverFixture _idriverFixture;
        private readonly TestSettings _testSettings;
        private readonly Lazy<WebDriverWait> _webDriverWait;

        public DriverWait(IDriverFixture idriverFixture, TestSettings testSettings)
        {
            _idriverFixture = idriverFixture;
            _testSettings = testSettings;
            _webDriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
        }

        public IWebElement FindElement(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _idriverFixture.Driver.FindElement(elementLocator));
        }

        public IEnumerable<IWebElement> FindElements(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _idriverFixture.Driver.FindElements(elementLocator));
        }

        private WebDriverWait GetWaitDriver()
        {
            return new WebDriverWait(_idriverFixture.Driver, timeout: TimeSpan.FromSeconds(_testSettings.TimeOutInternal ?? 30))
            {
                PollingInterval = TimeSpan.FromSeconds(_testSettings.TimeOutInternal ?? 1)
            };
        }
    }
}
