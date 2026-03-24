using Core.Interfaces;
using Infrastructure.UI.Actions;
using OpenQA.Selenium;

namespace Infrastructure.UI.Pages;

public class LoginPage
{
    private readonly ElementActions _elementActions;
    private readonly By _userNameFiled = By.Id("loginusername");
    private readonly By _passwordFiled = By.Id("loginpassword");
    private readonly By _loginButton = By.Id("login");
    private readonly By _userLabel = By.Id("cv_UserName");
    
    public LoginPage(ElementActions elementActions)
    {
        _elementActions = elementActions;
    }

    public void Login(string username, string password)
    {
        _elementActions.Type(_userNameFiled, username);
        _elementActions.Type(_passwordFiled, password);
        _elementActions.Click(_loginButton);
        
    }

    public bool IsLoginSuccessful()
    {
        return _elementActions.IsElemetDisplayed(_userLabel);
    }
}