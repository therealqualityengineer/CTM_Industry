using System.Text;
using Core.Interfaces;
using RestSharp;

namespace Framework.API;

public class ApiClient
{
    private readonly RestClient _client;
    
    public ApiClient(IConfig config)
    {
        _client = new RestClient(config.APIBaseUrl);
    }
    
    public RestResponse SendRequest(string endpoint, Method method, object? body = null, Dictionary<string, string>? headers = null, Dictionary<string, string>? query = null)
    {
        var request = new RestRequest(endpoint, method);
        request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("qaengineer:qaengineer@99")));
        
        if (query != null)
            foreach (var q in query)
                request.AddQueryParameter(q.Key, q.Value);
        
        request.AddQueryParameter("resultType", "json");
        
        if (body != null)
            request.AddJsonBody(body);

        return _client.Execute(request);
    }
}