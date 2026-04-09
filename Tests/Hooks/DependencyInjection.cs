using Application.Services;
using Core.Interfaces;
using Framework.API;
using Framework.Config;
using Framework.Interfaces;
using Framework.Services;
using Framework.TestData;
using Framework.UI.Actions;
using Framework.UI.Driver;
using Framework.UI.Pages;
using Infrastructure.UI.Pages;
using Infrastructure.UI.Waits;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using Tests.Context;

namespace Tests.Hooks;

[Binding]
public class DependencyInjection
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        // Config
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        services.AddSingleton<IConfiguration>(config);
        services.Configure<TestSettings>(config.GetSection("TestSettings"));
        services.AddSingleton<IConfig, ConfigReader>();

        // Driver
        services.AddScoped<IWebDriverManager, WebDriverManager>();

        // Services
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ICommonServices, CommonServices>();
        services.AddScoped<ITempManagerServices, TempManagerService>();
        services.AddScoped<IClientManagerServices, ClientManagerServices>();
        services.AddScoped<IOrderManagerServices, OrderManagerServices>();

        // Pages
        services.AddScoped<TempManagerPage>();
        services.AddScoped<LoginPage>();
        services.AddScoped<CommonPage>();
        services.AddScoped<BasePage>();
        services.AddScoped<ClientManagerPage>();
        services.AddScoped<OrderManagerPage>();
        services.AddScoped<ApiClient>();
        services.AddScoped<ApiService>();
        services.AddScoped<TestDataGenerator>();
        services.AddScoped<ResolveDynamic>();

        // UI Helpers
        services.AddScoped<ElementActions>();
        services.AddScoped<WaitService>();

        // Context
        services.AddScoped<ScenarioData>();
        services.AddScoped<DynamicDataGenerator>();

        return services;
    }
}