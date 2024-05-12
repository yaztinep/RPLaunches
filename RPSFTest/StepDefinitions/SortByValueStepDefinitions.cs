using RPFramework.Business.Pages;

namespace RPSFTest.StepDefinitions
{
    [Binding]
    public sealed class SortByValueStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IHomePage _ihomePage;
        private readonly ILoginPage _iloginPage;
        private readonly ILaunchesPage _ilaunchesPage;

        public SortByValueStepDefinitions(ScenarioContext scenarioContext,IHomePage ihomePage, ILoginPage iloginPage, ILaunchesPage ilaunchesPage)
        {
            _scenarioContext = scenarioContext;
            _ihomePage = ihomePage;
            _iloginPage = iloginPage;
            _ilaunchesPage = ilaunchesPage;
        }
        [Given(@"I login with the following credentials")]
        public void GivenILoginWithTheFollowingCredentials(Table table)
        {
            foreach (var row in table.Rows)
            {
                var username = row["username"];
                var password = row["password"];

                _iloginPage.Login(username, password);
            }
            
        }

        [Given(@"I go to the launches page")]
        public void GivenIGoToTheLaunchesPage()
        {
            _ihomePage.LaunchesDisplayed();
            _ihomePage.ClickLaunches();
        }

        [When(@"I filter by value")]
        public void WhenIFilterByValue(Table table)
        {
            _ilaunchesPage.ClickOnAddFilterButton();
            _ilaunchesPage.ClickOnDropdow();
            foreach (var row in table.Rows)
            {
                var value = row["value"];

                _ilaunchesPage.SelectOption(value);
            }
            
        }

        [Then(@"I should see the launches based on the value")]
        public void ThenIShouldSeeTheLaunchesBasedOnTheValue()
        {
            Console.WriteLine("Need to be defined");
        }

    }
}
