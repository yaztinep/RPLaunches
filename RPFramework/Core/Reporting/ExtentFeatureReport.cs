using TechTalk.SpecFlow.Bindings;
using AventStack.ExtentReports.Model;
using RPFramework.Core.Driver;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace RPFramework.Core.Reporting
{
    public class ExtentFeatureReport : IExtentFeatureReport
    {
        IExtentReport _iextentReport;
        AventStack.ExtentReports.ExtentTest _feature, _scenario, _step;
        public ExtentFeatureReport(IExtentReport iextentReport)
        {
            _iextentReport = iextentReport;
            _feature = null;
            _scenario = null;
            _step = null;
        }

        public void CreateFeature(string feature)
        {
            _feature = _iextentReport.GetExtentReports().CreateTest(feature);
        }

        public void CreateScenario(string scenario)
        {
            _scenario = _feature.CreateNode(scenario);
        }

        public void CreateFailScenario(string scenario,string failure, IDriverFixture driverFixture, string file)
        {
            _scenario = _feature.CreateNode(scenario).Fail(failure, new ScreenCapture()
            {
                Path = driverFixture.TakeScreenshotAsPath(file) ,
                Title ="Error screenshot"
            });
        }

        public void AddStepInformation(string feature, ScenarioContext scenario, Exception error, IDriverFixture driverFixture)
        {
            var fileName =
                $"{feature.Trim()}_{Regex.Replace(scenario.ScenarioInfo.Title, @"\s", "")}";
            if (error == null)
            {
                switch (scenario.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        CreateScenario(scenario.StepContext.StepInfo.Text);
                        break;
                    case StepDefinitionType.When:
                       CreateScenario(scenario.StepContext.StepInfo.Text);
                        break;
                    case StepDefinitionType.Then:
                        CreateScenario(scenario.StepContext.StepInfo.Text);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                switch (scenario.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                       CreateFailScenario(scenario.StepContext.StepInfo.Text, scenario.TestError.Message, driverFixture, fileName);
                        break;
                    case StepDefinitionType.When:
                       CreateFailScenario(scenario.StepContext.StepInfo.Text, scenario.TestError.Message, driverFixture, fileName);
                        break;
                    case StepDefinitionType.Then:
                        CreateFailScenario(scenario.StepContext.StepInfo.Text, scenario.TestError.Message, driverFixture, fileName);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

    }
}
