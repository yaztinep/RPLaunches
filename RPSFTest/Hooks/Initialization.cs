using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow.Bindings;
using RPFramework.Core.Reporting;
using System.Reflection;

namespace RPSFTest.Hooks
{
    [Binding]
    public class Initialization
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        public static IExtentReport _iextentReport;
        public static IExtentFeatureReport _iextentFeatureReport;

        public Initialization(ScenarioContext scenarioContext, FeatureContext featureContext, IExtentReport iextentReport, IExtentFeatureReport iextentFeatureReport)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _iextentReport = iextentReport;
            _iextentFeatureReport = iextentFeatureReport;
        }

        [BeforeTestRun] 
        public static void InitializeExtentReport()
        {
            _iextentReport.InitiliazeExtentReport();
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
            switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
            {
                case StepDefinitionType.Given:
                    _iextentFeatureReport.CreateScenario(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                case StepDefinitionType.When:
                    _iextentFeatureReport.CreateScenario(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                case StepDefinitionType.Then:
                    _iextentFeatureReport.CreateScenario(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _iextentReport.FlushExtentReport();
        }
    }
}
