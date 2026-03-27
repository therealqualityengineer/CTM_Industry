using Reqnroll;

namespace Tests.Context;

public class ScenarioData
{
    private readonly ScenarioContext _scenarioContext;
    
    public  ScenarioData(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    public void Set<T>(string key, T value)
    {
        _scenarioContext[key] = value;
    }

    public T Get<T>(string key)
    {
        if (_scenarioContext.TryGetValue(key, out var value))
        {
            return (T)value;
        }
        throw new KeyNotFoundException($"Key '{key}' not found in ScenarioContext");
    }
}