using Core.Interfaces;
using Framework.UI.Actions;
using OpenQA.Selenium;
using Reqnroll;

namespace Infrastructure.UI.Pages;

public class BasePage
{
    protected readonly IConfig _config;
    protected readonly ElementActions _actions;
    protected readonly IWebDriver _driver;

    protected BasePage(
        ElementActions actions,
        IConfig config,
        IWebDriverManager driverManager)
    {
        _config = config;
        _actions = actions;
        _driver = driverManager.Driver; 
    }
    
    protected IDictionary<string, string> ToDictionary(Table table)
    {
        return table.Rows.ToDictionary(row => row[0], row => row[1]);
    }
}