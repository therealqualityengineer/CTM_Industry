using System.Text;
using Core.Interfaces;
using Framework.Models.Enum;
using RestSharp;

namespace Framework.API;

public class ApiClient
{
    private readonly RestClient _client;
    
    public ApiClient(IConfig config)
    {
        _client = new RestClient(config.APIBaseUrl);
    }
    
    public RestResponse SendRequest(
        Method method,
        Dictionary<string, string> query,
        Dictionary<string, string>? body = null,
        BodyType bodyType = BodyType.Json)
    {
        var request = new RestRequest("", method);

        request.AddHeader("Authorization", GetAuthHeader());

        foreach (var q in query)
            request.AddQueryParameter(q.Key, q.Value);

        request.AddQueryParameter("resultType", "json");

        if (body != null)
        {
            switch (bodyType)
            {
                case BodyType.Multipart:
                    foreach (var item in body)
                        request.AddParameter(item.Key, item.Value);
                    break;

                case BodyType.Json:
                    request.AddJsonBody(body);
                    break;
            }
        }

        return _client.Execute(request);
    }
    
    private string GetAuthHeader()
    {
        return "Basic " + Convert.ToBase64String(
            Encoding.UTF8.GetBytes("qaengineer:Therealqaengineer@99")
        );
    }
}