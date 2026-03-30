using Reqnroll;
using RestSharp;

namespace Tests.Context;

public class ScenarioData
{
    private readonly ScenarioContext _scenarioContext;

    public ScenarioData(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    public void Set<T>(string key, T value) => _scenarioContext[key] = value;

    public T Get<T>(string key)
    {
        if (_scenarioContext.TryGetValue(key, out var value))
            return (T)value;

        throw new KeyNotFoundException($"Key '{key}' not found");
    }

    public RestResponse Response
    {
        get => Get<RestResponse>("response");
        set => Set("response", value);
    }
}