using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

namespace Framework.UI.Driver;

public class WebDriverManager : IWebDriverManager, IDisposable
{
    public IWebDriver Driver { get; }

    public WebDriverManager(IConfig config)
    {
        var isCI = Environment.GetEnvironmentVariable("CI") == "true";
        var useGrid = Environment.GetEnvironmentVariable("USE_GRID") == "true";
        var gridUrl = Environment.GetEnvironmentVariable("GRID_URL") ?? "http://localhost:4444/wd/hub";

        var envBrowser = Environment.GetEnvironmentVariable("BROWSER");
        var browser = string.IsNullOrWhiteSpace(envBrowser) ? config.Browser : envBrowser;

        Driver = browser.ToLower() switch
        {
            "chrome" => CreateChromeDriver(isCI, useGrid, gridUrl),
            "edge" => CreateEdgeDriver(isCI, useGrid, gridUrl),
            _ => CreateChromeDriver(isCI, useGrid, gridUrl)
        };

        Driver.Manage().Window.Maximize();
    }

    private IWebDriver CreateChromeDriver(bool isCI, bool useGrid, string gridUrl)
    {
        var options = new ChromeOptions();

        if (isCI)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }

        if (useGrid)
        {
            return new RemoteWebDriver(new Uri(gridUrl), options);
        }

        return new ChromeDriver(options);
    }

    private IWebDriver CreateEdgeDriver(bool isCI, bool useGrid, string gridUrl)
    {
        var options = new EdgeOptions();

        if (isCI)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        }

        if (useGrid)
        {
            return new RemoteWebDriver(new Uri(gridUrl), options);
        }

        return new EdgeDriver(options);
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}