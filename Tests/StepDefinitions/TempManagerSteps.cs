using Application.Services;
using Framework.Interfaces;
using Framework.Services;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class TempManagerSteps
{
    private readonly ITempManagerServices _tempManagerServices;
    private readonly ScenarioData _scenarioData;

    public TempManagerSteps(ITempManagerServices tempManagerServices, ScenarioData scenarioData)
    {
        _tempManagerServices = tempManagerServices;
        _scenarioData = scenarioData;
    }
    
    [Given("user creates a temp with following details")]
    public void GivenUserCreatesATempWithFollowingDetails(Table table)
    {
        var temp = _tempManagerServices.CreateTemp(table);
        
        Assert.That(_tempManagerServices.IsTempCreatedSuccessfully, Is.True, "Temp not created");
        
        _scenarioData.Set(ScenarioKeys.TempFirstName, temp["FirstName"]);
        _scenarioData.Set(ScenarioKeys.TempLastName, temp["LastName"]);
        _scenarioData.Set(ScenarioKeys.TempEmail, temp["PrimaryEmail"]);
        _scenarioData.Set(ScenarioKeys.TempId, temp["TempId"]);
        
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempId));
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempEmail));
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempFirstName));
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempLastName));
    }
}