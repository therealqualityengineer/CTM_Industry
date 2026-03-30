using Framework.Models.Enum;
using RestSharp;

namespace Framework.API;

public class ApiService
{
    private readonly ApiClient _apiClient;
    
    public ApiService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    private Method ResolveHttpMethod(string action)
    {
        return action switch
        {
            "getTemps" => Method.Get,
            "deleteTemp" => Method.Delete,
            "insertTemp" => Method.Post,
            "insertOrder" => Method.Post,
            _ => throw new NotSupportedException($"Unknown action: {action}")
        };
    }

    private BodyType ResolveBodyType(string action)
    {
        return action switch
        {
            "insertTemp" => BodyType.Multipart,
            "insertOrder" => BodyType.Multipart,
            _ => BodyType.Json
        };
    }
    
    public RestResponse Execute(string action, Dictionary<string, string> data)
    {
        var method = ResolveHttpMethod(action);
        var bodyType = ResolveBodyType(action);

        var query = new Dictionary<string, string>
        {
            { "action", action }
        };

        Dictionary<string, string>? body = null;

        if (method == Method.Get || method == Method.Delete)
        {
            foreach (var item in data)
                query[item.Key] = item.Value;
        }
        else if (method == Method.Post)
        {
            body = data;
        }

        return _apiClient.SendRequest(method, query, body, bodyType);
    }
}