using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace RPFramework.Core.Reporting
{
    public class ExtentReport : IExtentReport
    {
        public static ExtentReports _extentReports;
       

        public ExtentReport()
        {
            var extentReport =
                System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + @"\Results\Reports"
                 + DateTime.Now.ToString("yyyyMMdd hhmmss") + "/extentreport.html";
            _extentReports = new ExtentReports();
            var spark = new ExtentSparkReporter(extentReport);
            _extentReports.AttachReporter(spark);
        }

        public AventStack.ExtentReports.ExtentReports GetExtentReports()
        {
            return _extentReports;
        }

        public void FlushExtentReport()
        {
            _extentReports.Flush();
        }
    }
}
