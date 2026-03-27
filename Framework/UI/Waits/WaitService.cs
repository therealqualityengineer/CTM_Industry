using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Infrastructure.UI.Waits;

public class WaitService
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public WaitService(IWebDriverManager manager)
    {
        _driver = manager.Driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    public IWebElement WaitForElementVisible(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitForElementClickable(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    public IWebElement WaitForElementPresent(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementExists(locator));
    }

    public void WaitForNumberOfWindows()
    {
        _wait.Until(d => d.WindowHandles.Count > 1);
    }
}