namespace RPFramework.Core.Models
{
    public class Launch
    {
        public int launchId { get; set; }
        public string launchName { get; set; }
        public string build { get; set; }
    }

    public enum LaunchViewType
    {
        LaunchName,
        Total,
        Passed,
        Failed,
        Skipped,
        ProductBug,
        AutoBug,
        SystemIssue,
        ToInvestigate
    }
}
