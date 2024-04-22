using RPFramework.Business.Pages;

namespace RPTest
{
    public class SortByValueTest
    {
        private readonly IHomePage _ihomePage;
        private readonly ILoginPage _iloginPage;
        private readonly ILaunchesPage _ilaunchesPage;

        public SortByValueTest(IHomePage ihomePage, ILoginPage iloginPage, ILaunchesPage ilaunchesPage)
        {
            _ihomePage = ihomePage;
            _iloginPage = iloginPage;
            _ilaunchesPage = ilaunchesPage;
        }

        [Theory]
        [InlineData("Launch name")]
        [InlineData("Total")]
        [InlineData("Product Bug")]
        [InlineData("Passed")]
        [InlineData("Failed")]

        public void SortByValue(string sortValue)
        {
            _iloginPage.Login("default", "1q2w3e");
            _ihomePage.LaunchesDisplayed();
            _ilaunchesPage.ClickOnAddFilterButton();
            _ilaunchesPage.ClickOnDropdow();
            _ilaunchesPage.SelectOption(sortValue);
        }
    }
}