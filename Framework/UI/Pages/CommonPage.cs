using Core.Interfaces;
using Framework.Constant;
using Framework.UI.Actions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace Framework.UI.Pages;

public class CommonPage
{
    private readonly ElementActions _actions;
    private readonly IConfig _config;
    private By _partialTabName(string partialTabName) => By.Id($"cv_Tab_{partialTabName}");
    private readonly By _resetButton = By.Id("doReset");
    private readonly By _doSearchButton = By.Id("doSearch");
    private readonly By _clientSearchSeletor = By.Id("ClientEqualsOrContains_context");
    private readonly By _clientSearchText = By.Id("ClientEqualsOrContains_contains");
    private readonly By _ltorderSearchBox = By.Id("assignmentIDs");
    public By _subnavtext(string text) => By.XPath($"//a[text()='{text}']");
    public By _labelText(string text) => By.XPath($"//label[contains(text(),'{text}')]");
    
    public CommonPage(ElementActions elementActions,  IConfig config)
    {
        _actions = elementActions;
        _config = config;
    }

    public void NavigateToTab(string tabName)
    {
        _actions.Click(_partialTabName(tabName));
    }
    
    public void NavigateToPage(string pageName)
    {
        _actions.Driver.Navigate().GoToUrl($"{_config.BaseUrl}{pageName}");
    }
    
    public void SwitchToPage(string pageName)
    {
        _actions.SwitchToWindow(pageName);
    }
    
    public void NewSearchBoxwithClientSeach(string clientName)
    {
        _actions.Click(_resetButton);
        _actions.SelectDropdown(_clientSearchSeletor, "Contains");
        _actions.Type(_clientSearchText,clientName);
        _actions.Click(_doSearchButton);
    }

    public bool IsTextsDisplyed(string expectedText)
    {
        return _actions.IsElementDisplayed(_subnavtext(expectedText));
    }
    
    public void NavigateTo(string profileName, string id)
    {
        if(profileName.Equals("temp", StringComparison.OrdinalIgnoreCase))
        {
            _actions.Driver.Navigate().GoToUrl(_config.BaseUrl+PageUrls.TempProfileUrl+id);
        }
        else if (profileName.Equals("client", StringComparison.OrdinalIgnoreCase))
        {
            _actions.Driver.Navigate().GoToUrl(_config.BaseUrl+PageUrls.ClientProfileUrl+id);
        }
    }
    
    public void TypeInNewSearchBox(string filterFiled, string filterValue)
    {
        switch (filterFiled.ToLower())
        {
            case "assignmentid":
                _actions.Type(_ltorderSearchBox, filterValue);
                break;
            default:
                throw  new NotFoundException($"The filter {filterFiled} was not found.");
        }
    }
    
    public void ResetSearchBox()
    {
        _actions.Click(_resetButton);
    }

    public void SubmitSearch()
    {
        _actions.Click(_doSearchButton);
    }
}