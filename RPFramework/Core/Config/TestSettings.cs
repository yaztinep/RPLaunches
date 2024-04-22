using static RPFramework.Core.Driver.DriverFixture;

namespace RPFramework.Core.Config
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri Url { get; set; }
        public float? TimeOutInternal { get; set; }
        public TestRunType TestRunType { get; set; }
        public Uri GridUri { get; set; }

    }

    public enum TestRunType
    {
        Local,
        Grid
    }
}
