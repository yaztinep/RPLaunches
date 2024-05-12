using RPFramework.Core.Driver;
using TechTalk.SpecFlow;

namespace RPFramework.Core.Reporting
{
    public interface IExtentFeatureReport
    {
        void CreateFeature(string feature);
        void CreateScenario(string scenario);
        void CreateFailScenario(string scenario, string failure, IDriverFixture driverFixture, string file);
        void AddStepInformation(string feature, ScenarioContext scenario, Exception error, IDriverFixture driverFixture);
    }
}