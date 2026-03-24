using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using NUnit.Framework;

namespace Tests.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly ILoginService _loginService;

    public LoginSteps(ScenarioContext context)
    {
        var provider = (IServiceProvider)context["Services"];
        _loginService = provider.GetService<ILoginService>();
        
    }

    [Given("user login to {string} site with {string} credential to the {string} browser")]
    public void GivenUserLoginToSiteWithCredentialToTheBrowser(string site, string user, string browser)
    {
        Assert.That(_loginService.Login(site, user, browser), Is.True);
    }
}