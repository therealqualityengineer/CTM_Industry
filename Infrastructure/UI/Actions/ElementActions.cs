using Infrastructure.UI.Waits;
using OpenQA.Selenium;

namespace Infrastructure.UI.Actions;

public class ElementActions
{
    private readonly WaitService _waitService;
    
    public ElementActions(WaitService waitService)
    {
        _waitService = waitService;
    }

    public void Click(By locator)
    {
        _waitService.WaitForElementClickable(locator).Click();
    }

    public void Type(By locator, string type)
    {
        _waitService.WaitForElementClickable(locator).SendKeys(type);
    }

    public bool IsElemetDisplayed(By locator)
    {
        try
        {
            return _waitService.WaitForElementVisible(locator).Displayed;
        }
        catch (NoSuchElementException)
        {
            throw new NoSuchElementException();
        }
    }
}