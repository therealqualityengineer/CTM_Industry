using Core.Interfaces;
using Framework.Interfaces;
using Framework.UI.Pages;
using Infrastructure.UI.Pages;

namespace Application.Services;

public class LoginService : ILoginService
{
    private readonly IConfig _config;
    private readonly LoginPage _loginPage;

    public LoginService(IConfig config, LoginPage loginPage)
    {
        _config = config;
        _loginPage = loginPage;
    }

    public bool IsLoginSuccessful(string user)
    {
        var username = user.Equals("default", StringComparison.OrdinalIgnoreCase)
            ? _config.Username
            : user;

        var password = _config.Password;
        
        _loginPage.NavigateToLogin();
        _loginPage.Login(username, password);

        return _loginPage.IsLoginSuccessful();
    }
}