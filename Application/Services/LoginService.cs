using Core.Interfaces;
using Infrastructure.UI.Pages;

namespace Application.Services;

public class LoginService : ILoginService
{
    private readonly IConfig _config;
    private readonly LoginPage _loginPage;
    private readonly IWebDriverManager _manager;

    public LoginService(IConfig config, LoginPage loginPage, IWebDriverManager manager)
    {
        _config = config;
        _loginPage = loginPage;
        _manager = manager;
    }

    public bool Login(string site, string user, string browser)
    {
        var userName = user.Equals("default", StringComparison.InvariantCultureIgnoreCase)
            ? _config.Username
            : user;

        var password = _config.Password;

        var browserName = browser.Equals("default", StringComparison.InvariantCultureIgnoreCase)
            ? _config.Browser
            : browser;

        _manager.InitDriver(browserName);

        var driver = _manager.GetDriver(); 
        driver.Navigate().GoToUrl(_config.LoginUrl);

        _loginPage.Login(userName, password);
        return _loginPage.IsLoginSuccessful();
    }
}