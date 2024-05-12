using RPFramework.Business.Pages;

namespace RPTest
{
    [Collection("Test Collection 2")]
    public class LaunchViewByBuildNumberTest
    {
        private readonly IHomePage _ihomePage;
        private readonly ILoginPage _iloginPage;
        private readonly ILaunchesPage _ilaunchesPage;
        public LaunchViewByBuildNumberTest(IHomePage ihomePage, ILoginPage iloginPage, ILaunchesPage ilaunchesPage)
        {
            _ihomePage = ihomePage;
            _iloginPage = iloginPage;
            _ilaunchesPage = ilaunchesPage;
        }

        [Theory]
        [InlineData("Launch name", "3.21.2.5.30")]
        [InlineData("Total", "3.21.16.46.36")]
        [InlineData("Auto Bug", "3.21.16.46.51")]
        [InlineData("Passed", "3.21.2.5.25")]
        [InlineData("Failed", "3.21.2.5.21")]

        public void LaunchViewByBuildNumber(string view, string buildNumber)
        {
            _iloginPage.Login("default", "1q2w3e");
            _ihomePage.LaunchesDisplayed();
            _ilaunchesPage.ClickOnAddFilterButton();
            _ilaunchesPage.FindBuildNumber(buildNumber, "Attribute", "build");
            _ilaunchesPage.ClickOnView(view);

        }
    }
}
