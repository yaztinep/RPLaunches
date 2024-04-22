using Microsoft.Extensions.DependencyInjection;
using RPFramework.Business.Pages;
using RPFramework.Core.Config;
using RPFramework.Core.Driver;

namespace RPTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(ConfigReader.ReadConfig());
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IDriverWait, DriverWait>();
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ILoginPage, LoginPage>();
            services.AddScoped<ILaunchesPage, LaunchesPage>();
        }
    }
}
