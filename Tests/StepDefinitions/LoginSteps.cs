using Core.Interfaces;
using Framework.Interfaces;
using Reqnroll;

namespace Tests.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly ILoginService _loginService;

    public LoginSteps(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [Given("user login to the application with {string} credential")]
    public void GivenUserLoginToTheApplicationWithCredential(string user)
    {
        var result = _loginService.IsLoginSuccessful(user);
        Assert.That(result, Is.True);
    }
}