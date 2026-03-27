using System.Text.RegularExpressions;
using Framework.UI.Actions;
using OpenQA.Selenium;

namespace Framework.UI.Pages;

public class ClientManagerPage
{
    private readonly ElementActions _actions;
    
    private readonly By _newTempLink = By.XPath("//a[text()='New']");
    private readonly By _clientName =  By.Id("clientname"); 
    private readonly By _address =  By.Id("address");
    private readonly By _city =  By.Id("city");
    private readonly By _state =  By.Id("state");
    private readonly By _zip =  By.Id("zip");
    private readonly By _status =  By.Name("status");
    private readonly By _region =  By.Id("region");
    private readonly By _quickBooksId =  By.Id("quickbooksid");
    private readonly By _saveButton = By.Id("saveBtn");
    private readonly By _recordInfoLabel =  By.XPath("//legend[text()='Record Info']");
    private readonly By _recordInfo = By.XPath("//legend[text()='Record Info']/parent::fieldset[@class='cv-fieldset']"); 
    
    public ClientManagerPage(ElementActions elementActions)
    {
        _actions = elementActions;
    }
    
    public void ClickNew()
    {
        _actions.Click(_newTempLink);
    }
    
    public void EnterClientName(string value) => _actions.Type(_clientName, value);
    public void EnterAddress(string value) => _actions.Type(_address, value);
    public void EnterCity(string value) => _actions.Type(_city, value);
    public void EnterState(string value) => _actions.Type(_state, value);
    public void EnterZip(string value) => _actions.Type(_zip, value);
    public void SelectStatus(string value) => _actions.SelectDropdown(_status, value);
    public void SelectRegion(string value) => _actions.SelectDropdown(_region, value);
    public void QuickBooksId(string value) => _actions.Type(_quickBooksId, value);
    
    public void ClickSave()
    {
        _actions.Click(_saveButton);
    }

    public bool IsClientCreatedSuccessfully()
    {
        return _actions.IsElementDisplayed(_recordInfoLabel);
    }
    
    private string ExtractId(string tempRecord)
    {
        var match = Regex.Match(tempRecord, @"Client ID:\s*(\d+)");
        if (!match.Success)
            throw new Exception("Client ID not found");
        return match.Groups[1].Value;
    }

    public string GetClientId()
    {
        var clientId = ExtractId(_actions.GetText(_recordInfo));
        return clientId;
    }
}