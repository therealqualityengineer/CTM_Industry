using System.Text.RegularExpressions;
using Core.Interfaces;
using Framework.UI.Actions;
using Infrastructure.UI.Pages;
using OpenQA.Selenium;

namespace Framework.UI.Pages;

public class TempManagerPage : BasePage
{
    private readonly CommonPage _commonPage;
    
    private readonly By _firstName = By.Name("firstname");
    private readonly By _lastName = By.Name("lastname");
    private readonly By _email = By.Name("email");
    private readonly By _status = By.Name("status");
    private readonly By _homeRegion = By.Name("HomeRegion");
    private readonly By _contractEE = By.Name("contract_or_ee");
    private readonly By _address = By.Id("address");
    private readonly By _city = By.Id("city");
    private readonly By _state = By.Id("state");
    private readonly By _zip = By.Id("zip");
    private readonly By _newTempLink = By.XPath("//a[text()='New']");
    private readonly By _certification = By.Id("certstxt");
    private readonly By _specialty = By.Id("specstxt");
    private readonly By _saveButton = By.Id("saveBtn");
    private readonly By _tempCreatedLabel = By.XPath("//td[@class='cv-form-data'][contains(.,'Temp ID:')]");
    private readonly By _tempRecordInfo = By.XPath("//td[text()='Record Info']/following-sibling::td");
    private readonly By _payEdit = By.Name("temppayedit");
    private readonly By _flatEnable =  By.Name("howpay");
    private readonly By _flatPaytext = By.Name("payflat");
    private readonly By _flatBilltext = By.Name("billflat");
    private readonly By _saveTempPay = By.Name("temppayupdate");
    private By _flatPayBillDetails(string text) => By.XPath($"//b[text()='Flat Pay']/parent::td/following-sibling::td/descendant::b[contains(text(),'{text}')]");

    private By PartialText(string value) => By.XPath($"//li[text()='{value}']");

    public TempManagerPage(
        ElementActions actions,
        IConfig config,
        IWebDriverManager driverManager, CommonPage commonPage)
        : base(actions, config, driverManager)
    {
        _commonPage = commonPage;
    }

    public void ClickNew()
    {
        _actions.Click(_newTempLink);
    }

    public void EnterFirstName(string value) => _actions.Type(_firstName, value);
    public void EnterLastName(string value) => _actions.Type(_lastName, value);
    public void EnterEmail(string value) => _actions.Type(_email, value);
    public void EnterAddress(string value) => _actions.Type(_address, value);
    public void EnterCity(string value) => _actions.Type(_city, value);
    public void EnterState(string value) => _actions.Type(_state, value);
    public void EnterZip(string value) => _actions.Type(_zip, value);

    public void SelectStatus(string value) => _actions.SelectDropdown(_status, value);
    public void SelectHomeRegion(string value) => _actions.SelectDropdown(_homeRegion, value);
    public void SelectContract(string value) => _actions.SelectDropdown(_contractEE, value);

    public void SelectCertification(string value)
    {
        _actions.CustomSelect(_certification, value, PartialText(value));
    }

    public void SelectSpecialty(string value)
    {
        _actions.CustomSelect(_specialty, value, PartialText(value));
    }

    public void ClickSave()
    {
        _actions.Click(_saveButton);
    }

    public bool IsTempCreatedSuccessfully()
    {
        return _actions.IsElementDisplayed(_tempCreatedLabel);
    }
    
    public string ExtractTempId(string tempRecord)
    {
        var match = Regex.Match(tempRecord, @"Temp ID:\s*(\d+)");
        if (!match.Success)
            throw new Exception("Temp ID not found");
        return match.Groups[1].Value;
    }

    public string GetTempId()
    {
        return ExtractTempId(_actions.GetText(_tempRecordInfo));
    }

    public void ClickTempSubnav(string subnav)
    {
        _actions.Click(_commonPage._subnavtext(subnav));
    }

    public void ClickPayEdit()
    {
        _actions.Click(_payEdit);
    }
    
    public void ClickFlatEnable()
    {
        _actions.Click(_flatEnable);
    }

    public void EnterFlatPayBill(string key, string amount)
    {
        if(key == "PayFlat")
            _actions.Type(_flatPaytext, amount);
        else
            _actions.Type(_flatBilltext, amount);
    }

    public void TemppaySave()
    {
        _actions.Click(_saveTempPay);
    }

    public bool IsFlatPayBillEnabled(string status)
    {
        return _actions.IsElementDisplayed(_flatPayBillDetails(status));
    }

    public bool IsFlatPayAmountDisplayed(string amount)
    {
        return _actions.IsElementDisplayed(_flatPayBillDetails(amount));
    }
}