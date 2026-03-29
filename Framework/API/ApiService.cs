using RestSharp;

namespace Framework.API;

public class ApiService
{
    private readonly ApiClient _apiClient;
    
    public ApiService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    public RestResponse GetTemps(string endPoint, Dictionary<string,string> data)
    {
        return _apiClient.SendRequest(
            endPoint,
            Method.Get,
            query: data
        );
    }
}