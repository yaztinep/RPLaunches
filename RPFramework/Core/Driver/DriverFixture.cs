using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using RPFramework.Core.Config;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace RPFramework.Core.Driver
{
    public class DriverFixture : IDriverFixture
    {
        private readonly TestSettings _testSettings;

        public IWebDriver Driver { get; }

        public DriverFixture(TestSettings testSettings)
        {
            _testSettings = testSettings;
            Driver = _testSettings.TestRunType == TestRunType.Local ? GetWebDriver() : GetRemoteWebDriver();
            Driver.Navigate().GoToUrl(testSettings.Url);
        }

        private IWebDriver GetWebDriver()
        {
            return _testSettings.BrowserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.EdgeChromium => new EdgeDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => new ChromeDriver(),
            };
        }

        private IWebDriver GetRemoteWebDriver()
        {
            return _testSettings.BrowserType switch
            {
                BrowserType.Chrome => new RemoteWebDriver(_testSettings.GridUri,new ChromeOptions()),
                BrowserType.Firefox => new RemoteWebDriver(_testSettings.GridUri, new FirefoxOptions()),
                BrowserType.EdgeChromium => new RemoteWebDriver(_testSettings.GridUri, new EdgeOptions()),
                BrowserType.Safari => new RemoteWebDriver(_testSettings.GridUri, new SafariOptions()),
                _ => new RemoteWebDriver(_testSettings.GridUri, new ChromeOptions())
            };
        }

        public void Dispose()
        {
            Driver.Quit();  
        }

        public enum BrowserType
        {
            Chrome,
            Firefox,
            Safari,
            EdgeChromium
        }
    }
}
