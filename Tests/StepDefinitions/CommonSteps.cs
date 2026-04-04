using Core.Interfaces;
using Framework.Interfaces;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class CommonSteps
{
    private readonly ICommonServices  _commonServices;
    private readonly ScenarioData _scenarioData;
        
    public CommonSteps(ICommonServices commonServices, ScenarioData scenarioData)
    {
        _commonServices = commonServices;
        _scenarioData = scenarioData;
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

    [Then("the user verifies the following subnav link texts are displayed")]
    public void ThenTheUserVerifiesTheFollowingSubnavLinkTextsAreDisplayed(Reqnroll.Table table)
    {
        var texpectedTextList = table.Rows.Select(row => row[0]?.ToString())
            .Where(x => !string.IsNullOrEmpty(x)).ToList();
        _commonServices.VerifyTextDisplayed(texpectedTextList);
    }

    [Given("the user navigate to above created {string} profile")]
    public void GivenTheUserNavigateToAboveCreatedProfile(string profile)
    {
        string id;
        switch (profile)
        {
            case "temp":
                id = _scenarioData.Get<string>(ScenarioKeys.TempId);
                break;
            case "client":
                id = _scenarioData.Get<string>(ScenarioKeys.ClientId);
                break;
            default:
                throw new NotSupportedException($"Profile {profile} is not found");
        }
        _commonServices.NavigateToProfilePage(profile,id);
    }
}