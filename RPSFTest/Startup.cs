using Microsoft.Extensions.DependencyInjection;
using RPFramework.Business.Pages;
using RPFramework.Core.Config;
using RPFramework.Core.Driver;
using RPFramework.Core.Reporting;
using SolidToken.SpecFlow.DependencyInjection;

namespace RPSFTest
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateService()
        {
            var services = new ServiceCollection();
            services.AddSingleton(ConfigReader.ReadConfig());
            services.AddSingleton<IExtentReport, ExtentReport>();
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IDriverWait, DriverWait>();
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ILoginPage, LoginPage>();
            services.AddScoped<ILaunchesPage, LaunchesPage>();
            services.AddScoped<IExtentFeatureReport, ExtentFeatureReport>();
            return services;
        }
    }
}
