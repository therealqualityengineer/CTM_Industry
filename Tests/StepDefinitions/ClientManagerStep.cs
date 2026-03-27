using Framework.Interfaces;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class ClientManagerStep
{
    private readonly IClientManagerServices _clientManagerServices;
    private readonly ScenarioData _scenarioData;
    
    public ClientManagerStep(IClientManagerServices clientManagerServices, ScenarioData scenarioData)
    {
        _clientManagerServices = clientManagerServices;
        _scenarioData = scenarioData;
    }


    [Given("user creates a client with following details")]
    public void GivenUserCreatesAClientWithFollowingDetails(Reqnroll.Table table)
    {
        var clientData = _clientManagerServices.CreateClient(table);
        
        Assert.That(_clientManagerServices.IsClientCreatedSuccessfully, Is.True, "Client not create");
        
        _scenarioData.Set(ScenarioKeys.ClientName, clientData["ClientName"]);
        _scenarioData.Set(ScenarioKeys.ClientId, clientData["ClientId"]);
        
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.ClientName));
        Console.WriteLine(_scenarioData.Get<string>(ScenarioKeys.ClientId));
    }
}