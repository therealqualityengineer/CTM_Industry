using System.Net;
using Framework.API;
using Newtonsoft.Json.Linq;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class ApiSteps
{
    private readonly ApiService _apiService;
    private readonly ResolveDynamic _resolveDynamic;
    private readonly ScenarioData _scenarioData;
    
    public ApiSteps(ApiService apiService, ResolveDynamic resolveDynamic, ScenarioData scenarioData)
    {
        _apiService = apiService;
        _resolveDynamic = resolveDynamic;
        _scenarioData = scenarioData;
    }

    [Given("user sents {string} request")]
    public void GivenUserSentsRequest(string action, Reqnroll.Table table)
    {
        var data = table.Rows.ToDictionary(
            row => row["Field"],
            row => _resolveDynamic.ResolveDynamicValues(row["Value"])
        );
        var response = _apiService.Execute(action, data);
        _scenarioData.Response = response;
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Then("the user verifies the api response which {string} is {string}")]
    public void ThenTheUserVerifiesTheApiResponseWhichIs(string key, string expectedValue)
    {
        var content = _scenarioData.Response.Content.Trim();

        JToken token = content.StartsWith("[")
            ? JArray.Parse(content)[0]
            : JObject.Parse(content);

        var actualValue = token
            .Children<JProperty>()
            .FirstOrDefault(p => p.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
            ?.Value?.ToString();

        if (expectedValue.Equals("not null", StringComparison.OrdinalIgnoreCase))
        {
            Assert.That(actualValue, Is.Not.Null.And.Not.Empty,
                $"{key} should not be null or empty");
        }
        else
        {
            Assert.That(actualValue, Is.EqualTo(expectedValue),
                $"{key} mismatch");
        }

        StoreIfImportantKey(key, actualValue);
    }
    
    private void StoreIfImportantKey(string key, string value)
    {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "orderId", ScenarioKeys.OrderId },
            { "tempId", ScenarioKeys.TempId },
            { "clientId", ScenarioKeys.ClientId }
        };

        if (map.TryGetValue(key, out var scenarioKey))
        {
            _scenarioData.Set(scenarioKey, value);
        }
    }
}