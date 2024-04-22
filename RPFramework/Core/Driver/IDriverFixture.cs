using OpenQA.Selenium;

namespace RPFramework.Core.Driver
{
    public interface IDriverFixture
    {
        IWebDriver Driver { get; }
    }
}