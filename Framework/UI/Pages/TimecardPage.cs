using Framework.UI.Actions;
using OpenQA.Selenium;

namespace Framework.UI.Pages;

public class TimecardPage
{
    private readonly ElementActions _elementActions;
    private readonly CommonPage _commonPage;
    
    private readonly By _orderIdText = By.Id("orderid"); 
    private readonly By _showTimecard = By.Name("showtimecard");
    private readonly By _saveTimecard = By.Id("updatetimecard");
    
    public TimecardPage(ElementActions elementActions, CommonPage commonPage)
    {
        _elementActions = elementActions;    
        _commonPage = commonPage;
    }

    public void OpenTimecard(string orderid)
    {
        _elementActions.Type(_orderIdText, orderid);
        _elementActions.Click(_showTimecard);
        _commonPage.SwitchToWindow("Child");
    }

    public bool SaveTimecard()
    {
        _elementActions.Click(_saveTimecard);
        return _elementActions.IsElementDisplayed(_commonPage._devtext("Timecard saved."));
    }
}