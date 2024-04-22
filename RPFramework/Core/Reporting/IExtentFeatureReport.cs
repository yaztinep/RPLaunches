using AventStack.ExtentReports;

namespace RPFramework.Core.Reporting
{
    public interface IExtentFeatureReport
    {
        void AddStepInformation(string message, Status status, string base64);
        void CreateFeature(string feature);
        void CreateScenario(string scenario);
        void Error(string message, string base64);
        void Fail(string message, string base64);
        void Information(string message, string base64);
        void Pass(string message, string base64);
        void Warning(string message, string base64);
    }
}