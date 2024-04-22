using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace RPFramework.Business.Extensions
{
    public static class WebElementExtension
    {
        public static void SelectDropDownByText(this IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void SelectDropDownByValue(this IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public static void SelectDropDownByIndex(this IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static void SendText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

    }
}
