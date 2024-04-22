namespace RPFramework.Core.Config
{
    public interface IDefaultVariables
    {
        string ExtentReport { get; }
        string filePath { get; }
        string GridHubUrl { get; }
        string Log { get; }
        string Resources { get; }
        string Results { get; }
    }
}