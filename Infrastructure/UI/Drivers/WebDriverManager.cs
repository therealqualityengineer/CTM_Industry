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

        _driver = browser.ToLower() switch
        {
            "chrome" => new ChromeDriver(),
            "safari" => new SafariDriver(),
            _ => new ChromeDriver()
        };

        _driver.Manage().Window.Maximize();
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