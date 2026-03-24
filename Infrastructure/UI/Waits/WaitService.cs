using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Infrastructure.UI.Waits;

public class WaitService
{
    private readonly IWebDriverManager _manager;

    public WaitService(IWebDriverManager manager)
    {
        _manager = manager;
    }

    private WebDriverWait GetWait()
    {
        return new WebDriverWait(_manager.GetDriver(), TimeSpan.FromSeconds(15));
    }

    public IWebElement WaitForElementVisible(By locator)
    {
        return GetWait().Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitForElementClickable(By locator)
    {
        return GetWait().Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    public IWebElement WaitForElementPresent(By locator)
    {
        return GetWait().Until(ExpectedConditions.ElementExists(locator));
    }
}