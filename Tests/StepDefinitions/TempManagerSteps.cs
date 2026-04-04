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

    [Given("the user creates default temp")]
    public void GivenTheUserCreatesDefaultTemp()
    {
        var tempData = _tempManagerServices.CreateDefaultTemp();
        
        Assert.That(_tempManagerServices.IsTempCreatedSuccessfully, Is.True, "Temp not created");
        
        _scenarioData.Set(ScenarioKeys.TempFirstName, tempData.FirstName);
        _scenarioData.Set(ScenarioKeys.TempLastName, tempData.LastName);
        _scenarioData.Set(ScenarioKeys.TempEmail, tempData.Email);
        _scenarioData.Set(ScenarioKeys.TempId, tempData.TempId);
        
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempId));
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempFirstName));
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempLastName));
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.TempEmail));
        
    }

    [Given("the user enabled the flat pay and bill with following amount")]
    public void GivenTheUserEnabledTheFlatPayAndBillWithFollowingAmount(Reqnroll.Table table)
    {
        _tempManagerServices.EnterFlatPayBillAmount(table);
    }
    
    [Then("the user verifies flat pay bill setting {string} for temp with following amounts")]
    public void ThenTheUserVerifiesFlatPayBillSettingForTempWithFollowingAmounts(string status, Reqnroll.Table table)
    {
        var amountDetails = table.Rows.Select(row => row[0]?.ToString()).ToList();
        
        _tempManagerServices.IsFlatPayBillEnabledSuccessfully(status);
        _tempManagerServices.IsFlatPayBillAmountDisplayed(amountDetails);
    }
}