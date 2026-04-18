using Framework.Constant;
using Framework.UI.Actions;
using OpenQA.Selenium;

namespace Framework.UI.Pages;

public class OrderManagerPage
{
    private readonly ElementActions _actions;
    private readonly CommonPage _commonPage;
    
    private readonly By _newTempLink = By.XPath("//a[text()='New']");
    private readonly By _clientNameField = By.Id("clientname"); 
    private readonly By _tempNameFiled = By.Id("tempSelector");
    private readonly By _startDateFiled = By.Id("jobdatestart_display");
    private readonly By _shiftId = By.Id("shiftid");
    private readonly By _certification = By.Id("certstxt");
    private readonly By _specialty = By.Id("specstxt");
    private By _partialTextSelect(string value) => By.XPath($"//li[text()='{value}']");
    private readonly By _createDoneButton = By.Id("createdone");
    private readonly By _tempConfirmYNCheck = By.Name("TempConfirmYN");
    private readonly By _clientConfirmYNCheck = By.Name("ClientConfirmYN");
    private readonly By _fillOrderButton = By.Id("confirmed1");
    private readonly By _orderIdLabel = By.XPath("(//a[contains(@id,'view-shift-')])[2]");

    public OrderManagerPage(ElementActions elementActions, CommonPage commonPage)
    {
        _actions = elementActions;
        _commonPage = commonPage;
    }
    
    public void ClickNew()
    {
        _actions.Click(_newTempLink);
    }
    
    public void EnterClientName(string value) => _actions.TypeAndEnter(_clientNameField, value);
    public void EnterTempName(string value) => _actions.TypeAndEnter(_tempNameFiled, value);
    public void StartDate(string value) => _actions.Type(_startDateFiled, value);
    public void SelectShiftId(string value) => _actions.SelectDropdown(_shiftId, value);
    public void SelectCertification(string value) => _actions.CustomSelect(_certification, value, _partialTextSelect(value));
    public void SelectSpecialty(string value) => _actions.CustomSelect(_specialty, value, _partialTextSelect(value));

    public void CreateDone()
    {
        _actions.Click(_createDoneButton);
    }
    
    public void TempConfirmYn()
    {
        _actions.Click(_tempConfirmYNCheck);
    }
    
    public void ClientConfirmYn()
    {
        _actions.Click(_clientConfirmYNCheck);
    }
    
    public void FillOrder()
    {
        _actions.Click(_fillOrderButton);
    }

    public void SwitchToEditOrderWindow()
    {
        _commonPage.SwitchToWindow("Child");
    }
    
    public void SwitchToOrderManagerWindow()
    {
        _commonPage.SwitchToWindow("Parent");
    }
    
    public void NavigateToNewOrderPage()
    {
        _commonPage.NavigateToPage(PageUrls.NewOrderPageUrl);
    }

    public void ClientSearchinOrderSearchBox(string clientName)
    {
        _commonPage.NewSearchBoxwithClientSeach(clientName);
    }

    public string GetorderId()
    {
        return _actions.GetText(_orderIdLabel).Split(' ')[1];
    }
}