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
}