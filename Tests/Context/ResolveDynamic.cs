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

        var map = new Dictionary<string, Func<string>>(StringComparer.OrdinalIgnoreCase)
        {
            ["<scenario_clientname>"] = () => _scenarioData.Get<string>(ScenarioKeys.ClientName),
            ["<scenario_tempfirstname>"] = () => _scenarioData.Get<string>(ScenarioKeys.TempFirstName),
            ["<scenario_tempid>"] = () => _scenarioData.Get<string>(ScenarioKeys.TempId),
            ["<scenario_clientid>"] = () => _scenarioData.Get<string>(ScenarioKeys.ClientId),
            ["<scenario_ltorderid>"] = () => _scenarioData.Get<string>(ScenarioKeys.LTorderId),
            ["<scenario_orderid>"] = () => _scenarioData.Get<string>(ScenarioKeys.OrderId),
            ["<scenario_ratesheetid>"] = () => _scenarioData.Get<string>(ScenarioKeys.RatesheetId)
        };

        foreach (var kvp in map)
        {
            if (input.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace(kvp.Key, kvp.Value(), StringComparison.OrdinalIgnoreCase);
            }
        }

        return input;
    }
}