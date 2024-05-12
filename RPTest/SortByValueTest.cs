using RPFramework.Business.Pages;
//[assembly: CollectionBehavior(DisableTestParallelization = false)]

namespace RPTest
{
    [Collection("Test Collection")]
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

        public static IEnumerable<object[]> SortValues()
        {
            yield return new object[] { "Launch name" };
            yield return new object[] { "Total" };
            yield return new object[] { "Product Bug" };
            yield return new object[] { "Passed" };
            yield return new object[] { "Failed" };
        }

        [Theory]
        //[MemberData(nameof(SortValues))] 
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