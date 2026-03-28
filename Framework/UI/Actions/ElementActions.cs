using Core.Interfaces;
using Infrastructure.UI.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.UI.Actions;

public class ElementActions
{
    private readonly WaitService _waitService;
    private readonly IWebDriver _driver;
    
    public IWebDriver Driver => _driver;

    public ElementActions(WaitService waitService, IWebDriverManager driverManager)
    {
        _waitService = waitService;
        _driver = driverManager.Driver;
    }

    public void Click(By locator)
    {
        try
        {
            _waitService.WaitForElementClickable(locator).Click();
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"[Click FAILED] Locator: {locator} | Error: {ex.Message}",
                ex
            );
        }
    }

    public void Type(By locator, string text)
    {
        try
        {
            var element = _waitService.WaitForElementVisible(locator);

            element.Clear();
            element.SendKeys(text);
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"[Type FAILED] Locator: {locator} | Value: '{text}' | Error: {ex.Message}",
                ex
            );
        }
    }

    public bool IsElementDisplayed(By locator)
    {
        try
        {
            return _waitService.WaitForElementVisible(locator).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void TypeAndEnter(By locator, string text)
    {
        var element = _waitService.WaitForElementVisible(locator);
        element.Clear();
        element.SendKeys(text + Keys.Enter);
        WaitForDomStability();
    }

    public string GetText(By locator)
    {
        return _waitService.WaitForElementVisible(locator).Text;
    }

    public void SelectDropdown(By locator, string value, string type = "text")
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Dropdown value cannot be null or empty");

        var element = _waitService.WaitForElementClickable(locator);

        try
        {
            var select = new SelectElement(element);

            switch (type.ToLower())
            {
                case "value":
                    select.SelectByValue(value);
                    break;

                case "text":
                    select.SelectByText(value);
                    break;

                case "index":
                    select.SelectByIndex(int.Parse(value));
                    break;

                default:
                    throw new Exception($"Invalid dropdown selection type: {type}");
            }
        }
        catch (UnexpectedTagNameException)
        {
            // Custom dropdown fallback
            element.Click();

            var option = By.XPath($"//*[text()='{value}']");
            _waitService.WaitForElementClickable(option).Click();
        }
    }

    public void CustomSelect(By inputLocator, string text, By optionLocator)
    {
        Type(inputLocator, text);
        Click(optionLocator);
    }

    public void SwitchToWindow(string pageTitle)
    {
        _waitService.WaitForNumberOfWindows();

        foreach (var window in _driver.WindowHandles)
        {
            _driver.SwitchTo().Window(window);

            if (_driver.Title == pageTitle)
                return;
        }

        throw new Exception($"Unable to find page title: {pageTitle}");
    }

    public void WaitForDomStability(int milliseconds = 2000)
    {
        Thread.Sleep(milliseconds); // controlled usage
    }
}