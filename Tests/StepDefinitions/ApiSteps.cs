using System.Net;
using Framework.API;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class ApiSteps
{
    private readonly ApiService _apiService;
    private ResolveDynamic _resolveDynamic;
    
    public ApiSteps(ApiService apiService, ResolveDynamic resolveDynamic)
    {
        _apiService = apiService;
        _resolveDynamic = resolveDynamic;
    }

    [Given("user calls an API with")]
    public void GivenUserCallsAnApiWith(Reqnroll.Table table)
    {
        var data = table.Rows.ToDictionary(row => row[0], row => _resolveDynamic.ResolveDynamicValues(row[1]));
        var response = _apiService.GetTemps("", data);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var response1 = response.Content;
        Console.WriteLine(response1);
    }
}