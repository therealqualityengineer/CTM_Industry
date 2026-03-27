using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Framework.UI.Drivers;

public class WebDriverManager : IWebDriverManager, IDisposable
{
    public IWebDriver Driver { get; }

    public WebDriverManager(IConfig config)
    {
        var isCI = Environment.GetEnvironmentVariable("CI") == "true";
        var envBrowser = Environment.GetEnvironmentVariable("BROWSER");
        var browser = String.IsNullOrWhiteSpace(envBrowser) ? config.Browser : envBrowser;

        Driver = browser.ToLower() switch
        {
            "chrome" => CreateChromeDriver(isCI),
            "edge" => CreateEdgeDriver(isCI),
            _ => CreateChromeDriver(isCI)
        };

        Driver.Manage().Window.Maximize();
    }

    private IWebDriver CreateChromeDriver(bool isCI)
    {
        var options = new ChromeOptions();

        if (isCI)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }

        return new ChromeDriver(options);
    }

    private IWebDriver CreateEdgeDriver(bool isCI)
    {
        var options = new EdgeOptions();

        if (isCI)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }

        return new EdgeDriver(options);
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}