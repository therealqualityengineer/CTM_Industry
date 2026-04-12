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
    private readonly By _ratesheetId = By.Id("ratesheetID");
    private readonly By _addTaxableitem = By.Id("addTaxableLineItem");
    private readonly By _addNonTaxableitem = By.Id("addNonTaxableLineItem");
    private By _deductionType(int n) => By.Id($"deduction-type-input-row-{n}");
    private By _deductionFrequency(int n) => By.Id($"deduction-frequency-input-row-{n}");
    private By _deductionAmount(int n) => By.Id($"deduction-amount-input-row-{n}");
    private By _deductionDays(int n) => By.Id($"deduction-days-input-row-{n}");
    private By _deductionDate(int n) => By.Id($"deduction-date-input-row-{n}");
    private By _deductionProcap(int n) => By.Id($"deduction-procap-input-row-{n}");
    private By _deductionHours(int n) => By.Id($"deduction-hours-input-row-{n}");
    private By _openRatesheet(string ratesheetId) => By.XPath($"(//a[contains(text(),'{ratesheetId}')])[2]");
    
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
       return _elementActions.GetText(_ratesheetId).Split('#')[1].Trim();
    }

    public void OpenRatesheet(string ratesheetId)
    {
        _elementActions.Click(_openRatesheet(ratesheetId));
        _commonPage.SwitchToPage("Rate Sheet");
    }

    public void AddTaxableItem()
    {
        _elementActions.Click(_addTaxableitem);
    }
    
    public void AddNonTaxableItem()
    {
        _elementActions.Click(_addNonTaxableitem);
    }
    
    public void AddChangestoRatesheet(string header, string value, int n)
    {
        switch (header.ToLower())
        {
            case "item":
                _elementActions.SelectDropdown(_deductionType(n), value);
                break;
            case "pay frequency":
                _elementActions.SelectDropdown(_deductionFrequency(n), value);
                break;
            case "amount":
                _elementActions.TypeAmount(_deductionAmount(n), value);
                break;
            case "days per week":
                _elementActions.SelectDropdown(_deductionDays(n), value);
                break;
            case "defer to date":
                _elementActions.Type(_deductionDate(n), value);
                break;
            case "prorate / cap":
                _elementActions.SelectDropdown(_deductionProcap(n), value);
                break;
            case "hours per period":
                _elementActions.Type(_deductionHours(n), value);
                break;
            default:
                throw new NotFoundException($"{header} is not a valid option to select");
        }
    }

    public void SaveRatesheet()
    {
        _elementActions.Click(_saveRatesheetButton);
        Assert.That(_elementActions.IsElementDisplayed(_ratesheetMessageAlert),  Is.True, "Rate sheet message alert is not displayed");
    }
}