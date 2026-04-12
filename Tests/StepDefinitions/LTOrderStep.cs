using Framework.Interfaces;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class LTOrderStep
{
    private readonly ILtOrderServices _ltOrderServices;
    private readonly ScenarioData _scenarioData;
   
    public LTOrderStep(ILtOrderServices ltOrderServices, ScenarioData scenarioData)
    {
        _ltOrderServices = ltOrderServices;
        _scenarioData = scenarioData;
    }


    [Given("the user creates default Ratesheet for the selected LTorder")]
    public void GivenTheUserCreatesDefaultRatesheetForTheSelectedLTorder()
    {
        var ratesheetId = _ltOrderServices.CreateDefaultRatesheetForLtOrder();
        
        _scenarioData.Set(ScenarioKeys.RatesheetId, ratesheetId);
    }
}