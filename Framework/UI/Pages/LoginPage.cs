using Core.Interfaces;
using Framework.UI.Actions;
using OpenQA.Selenium;

namespace Framework.UI.Pages;

public class LoginPage
{
    private readonly ElementActions _actions;
    private readonly IConfig _config;

    // 🔹 Locators
    private readonly By _usernameField = By.Id("loginusername");
    private readonly By _passwordField = By.Id("loginpassword");
    private readonly By _loginButton = By.Id("login");
    private readonly By _userLabel = By.Id("cv_UserName");

    public LoginPage(ElementActions actions, IConfig config)
    {
        _actions = actions;
        _config = config;
    }

    // 🔹 Navigation
    public void NavigateToLogin()
    {
        _actions.Driver.Navigate().GoToUrl(_config.LoginUrl);
    }

    // 🔹 Actions
    public void EnterUsername(string username)
    {
        _actions.Type(_usernameField, username);
    }

    public void EnterPassword(string password)
    {
        _actions.Type(_passwordField, password);
    }

    public void ClickLogin()
    {
        _actions.Click(_loginButton);
    }

    // 🔹 Business Flow (optional but useful)
    public void Login(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLogin();
    }

    // 🔹 Validation
    public bool IsLoginSuccessful()
    {
        return _actions.IsElementDisplayed(_userLabel);
    }
}