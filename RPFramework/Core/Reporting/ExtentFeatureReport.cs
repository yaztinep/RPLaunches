using AventStack.ExtentReports;

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

        public void AddStepInformation(string message, Status status, string base64)
        {
            if (base64 == null)
            {
                _scenario.Log(status, message);
            }
            else
            {
                _scenario.Log(status, message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
            }
        }

        public void Pass(string message, string base64)
        {
            AddStepInformation(message, Status.Pass, base64);
        }

        public void Error(string message, string base64)
        {
            AddStepInformation(message, Status.Error, base64);
        }

        public void Information(string message, string base64)
        {
            AddStepInformation(message, Status.Info, base64);
        }

        public void Warning(string message, string base64)
        {
            AddStepInformation(message, Status.Warning, base64);
        }

        public void Fail(string message, string base64)
        {
            AddStepInformation(message, Status.Fail, base64);
        }
    }
}
