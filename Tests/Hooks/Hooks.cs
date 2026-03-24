using Application.Services;
using Core.Interfaces;
using Infrastructure.Config;
using Infrastructure.UI.Actions;
using Infrastructure.UI.Drivers;
using Infrastructure.UI.Pages;
using Infrastructure.UI.Waits;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;

namespace Tests.Hooks;
[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;
    
    public Hooks(ScenarioContext context)
    {
        _context = context;
    }
    
    [BeforeScenario]
    public void Setup()
    {
        var services = new ServiceCollection();
        
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
        
        services.AddSingleton<IConfiguration>(config);
        services.AddSingleton<IConfig, ConfigReader>();

        services.AddScoped<IWebDriverManager, WebDriverManager>();
        services.AddScoped<ILoginService, LoginService>();
        
        services.AddScoped<LoginPage>();
        services.AddScoped<ElementActions>();
        services.AddScoped<WaitService>();
        
        var provider = services.BuildServiceProvider();
        
        _context["Services"] =  provider;
    }
    
    [AfterScenario]
    public void Dispose()
    {
        var provider = (IServiceProvider)_context["Services"];

        var driverManager = provider.GetService<IWebDriverManager>();

        driverManager?.QuitDriver();
    }
}