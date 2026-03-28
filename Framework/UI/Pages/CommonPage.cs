using Core.Interfaces;
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
}