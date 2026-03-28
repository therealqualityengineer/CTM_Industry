namespace Tests.Context;

public class ResolveDynamic
{
    private readonly ScenarioData _scenarioData;
    public ResolveDynamic(ScenarioData scenarioData)
    {
        _scenarioData = scenarioData;
    }
    
    public string ResolveDynamicValues(string  input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;
        if(input.Contains("<scenario_clientname>", StringComparison.OrdinalIgnoreCase))
        {
            input = input.Replace("<scenario_clientname>", _scenarioData.Get<string>(ScenarioKeys.ClientName));
        }
        if (input.Contains("<scenario_tempfirstname>", StringComparison.OrdinalIgnoreCase))
        {
            input = input.Replace("<scenario_tempfirstname>", _scenarioData.Get<string>(ScenarioKeys.TempFirstName));
        }
        if (input.Contains("<scenario_tempid>", StringComparison.OrdinalIgnoreCase))
        {
            input = input.Replace("<scenario_tempid>", _scenarioData.Get<string>(ScenarioKeys.TempId));
        }
        if (input.Contains("<scenario_clientid>", StringComparison.OrdinalIgnoreCase))
        {
            input = input.Replace("<scenario_clientid>", _scenarioData.Get<string>(ScenarioKeys.ClientId));
        }
        return input;
    }
}