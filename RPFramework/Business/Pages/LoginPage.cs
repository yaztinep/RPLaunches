using OpenQA.Selenium;
using RPFramework.Core.Driver;

namespace RPFramework.Business.Pages
{
    public interface ILoginPage
    {
        void Login(string username, string password);
    }

    public class LoginPage : ILoginPage
    {
        private readonly IDriverWait _idriverWait;

        public LoginPage(IDriverWait idriverWait)
        {
            _idriverWait = idriverWait;
        }
        private IWebElement loginInput => _idriverWait.FindElement(By.Name("login"));
        private IWebElement passwordInput => _idriverWait.FindElement(By.Name("password"));
        private IWebElement loginButton => _idriverWait.FindElement(By.CssSelector("div.loginForm__login-button-container--KT9g6 > button"));

        public void Login(string username, string password)
        {
            /*loginInput.SendText(username);
            passwordInput.SendText(password);*/
            loginButton.Click();
        }

    }
}
