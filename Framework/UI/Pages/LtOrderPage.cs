using Framework.UI.Actions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework.UI.Pages;

public class LtOrderPage
{
    private readonly ElementActions _elementActions;
    private readonly CommonPage _commonPage;
    
    private readonly By _rateSheetButton = By.XPath("(//a[contains(@class,'view-ratesheet')])[3]");
    private readonly By _saveRatesheetButton = By.Id("saveRateSheetBtn");
    private readonly By _ratesheetMessageAlert = By.CssSelector("div.bootstrap-growl.alert-success");
    private readonly By _ratesheetID = By.Id("ratesheetID");
    
    public LtOrderPage(ElementActions elementActions, CommonPage commonPage)
    {
        _elementActions = elementActions;
        _commonPage = commonPage;
    }
    
    public string CreateRateSheetFromLto()
    {
        _elementActions.Click(_rateSheetButton);
        _commonPage.SwitchToPage("Rate Sheet");
        Assert.That(_elementActions.IsElementDisplayed(_commonPage._labelText("New Rate Sheet")),  Is.True, "New Rate Sheet is not displayed");
        _elementActions.Click(_saveRatesheetButton);
       Assert.That(_elementActions.IsElementDisplayed(_ratesheetMessageAlert),  Is.True, "Rate sheet message alert is not displayed");
       return _elementActions.GetText(_ratesheetID).Split('#')[1].Trim();
    }
}