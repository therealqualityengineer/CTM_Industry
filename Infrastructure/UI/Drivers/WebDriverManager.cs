using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;

namespace Infrastructure.UI.Drivers;

public class WebDriverManager : IWebDriverManager
{
    private IWebDriver _driver;

    public void InitDriver(string browser)
    {
        if (_driver != null) return;
        
        var isCI = Environment.GetEnvironmentVariable("CI") == "true";
        
        _driver = browser.ToLower() switch
        {
            "chrome" => CreateChromeDriver(isCI),
            "edge" => CreateEdgeDriver(isCI),
            _ => CreateChromeDriver(isCI)
        };
        _driver.Manage().Window.Maximize();
    }

    public IWebDriver CreateChromeDriver(bool isCI)
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

    public IWebDriver CreateEdgeDriver(bool isCI)
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

    public IWebDriver GetDriver()
    {
        if (_driver == null)
            throw new Exception("Driver not initialized. Call InitDriver first.");

        return _driver;
    }

    public void QuitDriver()
    {
        _driver?.Quit();
        _driver = null;
    }
}