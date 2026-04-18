using Framework.Interfaces;
using Framework.Services;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class LTOrderStep
{
    private readonly ILtOrderServices _ltOrderServices;
    private readonly ScenarioData _scenarioData;
    private readonly ResolveDynamic _resolveDynamic;
    private readonly ICommonServices _commonServices;
    private readonly DynamicDataGenerator _dynamicDataGenerator;
   
    public LTOrderStep(ILtOrderServices ltOrderServices, ScenarioData scenarioData, ResolveDynamic resolveDynamic, ICommonServices commonServices, DynamicDataGenerator dynamicDataGenerator)
    {
        _ltOrderServices = ltOrderServices;
        _scenarioData = scenarioData;
        _resolveDynamic = resolveDynamic;
        _commonServices = commonServices;
        _dynamicDataGenerator = dynamicDataGenerator;
    }


    [Given("the user creates default Ratesheet for the selected LTorder")]
    public void GivenTheUserCreatesDefaultRatesheetForTheSelectedLTorder()
    {
        var ratesheetId = _ltOrderServices.CreateDefaultRatesheetForLtOrder();
        
        _scenarioData.Set(ScenarioKeys.RatesheetId, ratesheetId);
    }
    
    [Given("the user open the {string} ratesheet")]
    public void GivenTheUserOpenTheRatesheet(string ratesheetid)
    {
        var ratesheetId = _resolveDynamic.ResolveDynamicValues(ratesheetid);
        
        _commonServices.NavigateToPage("index2.cfm?action=ratesheets.search");
        var ratesheetDetails = new Dictionary<string, string> { {"RatesheetId", ratesheetId} };
        _commonServices.FilterOnNewSearchBox(ratesheetDetails);
        _ltOrderServices.OpenRatesheet(ratesheetId);
    }

    [Then("the user saves the ratesheet")]
    public void ThenTheUserSavesTheRatesheet()
    {
        _ltOrderServices.SaveRatesheet();
    }

    [Given("the user adds the following {string} to the ratesheet")]
    public void GivenTheUserAddsTheFollowingToTheRatesheet(string item, Reqnroll.Table table)
    {
        var itemTable = table.Rows.Select(r => table.Header.ToDictionary(h => h, h => _dynamicDataGenerator.Resolve(r[h]))).ToList();
        _ltOrderServices.AddChangestoRatesheetId(item, itemTable);
    }
}