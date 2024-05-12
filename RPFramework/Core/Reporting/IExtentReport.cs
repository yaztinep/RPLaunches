using AventStack.ExtentReports;

namespace RPFramework.Core.Reporting
{
    public interface IExtentReport
    {
        void FlushExtentReport();
        ExtentReports GetExtentReports();
    }
}