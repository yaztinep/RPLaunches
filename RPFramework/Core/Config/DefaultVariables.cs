using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPFramework.Core.Config
{
    public class DefaultVariables : IDefaultVariables
    {
        public string Results
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + @"\Results\Reports"
                + DateTime.Now.ToString("yyyyMMdd hhmmss");
            }
        }

        public string Log
        {
            get
            {
                return Results + "\\log.txt";
            }
        }

        public string ExtentReport
        {
            get
            {
                return Results + "\\result.html";
            }
        }

        public string Resources
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\Resources";
            }
        }

        public string GridHubUrl
        {
            get
            {
                return "https://localhost:4444/wd/hub";
            }
        }

        public string filePath
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\DataSetLocation";
            }
        }
    }
}
