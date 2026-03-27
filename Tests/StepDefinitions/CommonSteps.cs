using Core.Interfaces;
using Framework.Interfaces;
using Reqnroll;

namespace Tests.StepDefinitions;

[Binding]
public class CommonSteps
{
    private readonly ICommonServices  _commonServices;
        
    public CommonSteps(ICommonServices commonServices)
    {
        _commonServices = commonServices;
    }
    
    [Given("user navigate to the {string} tab")]
    public void GivenUserNavigateToTheTab(string tabName)
    {
        _commonServices.NavigateToTab(tabName);
    }

    [Given("user navigate to {string} page")]
    public void GivenUserNavigateToPage(string partialUrl)
    {
        _commonServices.NavigateToPage(partialUrl);
    }
}