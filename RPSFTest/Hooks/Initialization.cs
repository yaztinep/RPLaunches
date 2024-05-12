using RPFramework.Core.Reporting;
using RPFramework.Core.Driver;

namespace RPSFTest.Hooks
{
    [Binding]
    public class Initialization
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        public static IExtentReport _iextentReport;
        public static IExtentFeatureReport _iextentFeatureReport;
        private readonly IDriverFixture _driverFixture;

        public Initialization(ScenarioContext scenarioContext, FeatureContext featureContext, IExtentReport iextentReport, IExtentFeatureReport iextentFeatureReport,IDriverFixture idriverFixture)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _iextentReport = iextentReport;
            _iextentFeatureReport = iextentFeatureReport;
            _driverFixture = idriverFixture;
        }

        [BeforeTestRun] 
        public static void InitializeExtentReport()
        {

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _iextentFeatureReport.CreateFeature(_featureContext.FeatureInfo.Title);
            _iextentFeatureReport.CreateScenario(_scenarioContext.ScenarioInfo.Title);

        }

        [AfterStep]
        public void AfterStep()
        {
            _iextentFeatureReport.AddStepInformation(_featureContext.FeatureInfo.Title, _scenarioContext, _scenarioContext.TestError, _driverFixture);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _iextentReport.FlushExtentReport();
        }
    }
}
