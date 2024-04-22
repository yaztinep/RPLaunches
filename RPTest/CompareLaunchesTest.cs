using RPFramework.Business.Pages;

namespace RPTest
{
    public class CompareLaunchesTest
    {
        private readonly IHomePage _ihomePage;
        private readonly ILoginPage _iloginPage;
        private readonly ILaunchesPage _ilaunchesPage;

        public CompareLaunchesTest(IHomePage ihomePage, ILoginPage iloginPage, ILaunchesPage ilaunchesPage)
        {
            _ihomePage = ihomePage;
            _iloginPage = iloginPage;
            _ilaunchesPage = ilaunchesPage;
        }
        [Theory]
        [InlineData(new object[] { new int[] { 1, 2 } })]
        [InlineData(new object[] { new int[] { 1, 2, 5 } })]
        [InlineData(new object[] { new int[] { 1, 5 } })]
        [InlineData(new object[] { new int[] { 2, 6 } })]
        [InlineData(new object[] { new int[] { 1, 6 } })]

        public void CompareLaunches(int[] options)
        {
            _iloginPage.Login("default", "1q2w3e");
            _ihomePage.LaunchesDisplayed();
            _ilaunchesPage.SelectLaunches(options);
            _ilaunchesPage.Action("Compare");
        }
    }
}
