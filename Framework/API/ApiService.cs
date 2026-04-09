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
            "insertTempRecords" => Method.Post,
            "insertClients"  => Method.Post,
            "insertOrder" => Method.Post,
            "insertLTorder" => Method.Post,
            "getClients" => Method.Get,
            _ => throw new NotSupportedException($"Unknown action: {action}")
        };
    }

    private BodyType ResolveBodyType(string action)
    {
        return action switch
        {
            "insertTempRecords" => BodyType.Multipart,
            "insertClients"  => BodyType.Multipart,
            "insertOrder" => BodyType.Multipart,
            "insertLTorder" => BodyType.Multipart,
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
            if (action == "insertTempRecords" || action == "insertClients")
            {
                string xml = action switch
                {
                    "insertTempRecords" => BuildTempXml(data),
                    "insertClients" => BuildClientXml(data),
                    _ => throw new NotSupportedException($"Unknown action: {action}")
                };
                
                string param = action switch
                {
                    "insertTempRecords" => "tempRecords",
                    "insertClients" => "clientRecords",
                    _ => throw new NotSupportedException($"Unknown action: {action}")
                };
                
                body = new Dictionary<string, string>
                {
                    { param, xml },
                    { "resultType", "json" }
                };
            }
            else
            {
                body = data;
            }
        }
        return _apiClient.SendRequest(method, query, body, bodyType);
    }
    
    public string BuildTempXml(Dictionary<string, string> data)
    {
        return $@"
            <tempRecords>
                <tempRecord>
                    <firstName>{data["firstName"]}</firstName>
                    <lastName>{data["lastName"]}</lastName>
                    <Address>{data["Address"]}</Address>
                    <city>{data["City"]}</city>
                    <state>{data["State"]}</state>
                    <zip>{data["Zip"]}</zip>
                    <status>{data["status"]}</status>
                    <homeRegion>{data["homeregion"]}</homeRegion>
                    <certification>{data["certification"]}</certification>
                    <specialty>{data["specialty"]}</specialty>
                </tempRecord>
            </tempRecords>";
    }
    
    public string BuildClientXml(Dictionary<string, string> data)
    {
        return $@"
            <clientRecords>
                <record>
                    <clientName>{data["clientName"]}</clientName>
                    <Address>{data["Address"]}</Address>
                    <city>{data["City"]}</city>
                    <state>{data["State"]}</state>
                    <zip>{data["Zip"]}</zip>
                    <status>{data["status"]}</status>
                    <regionId>{data["regionId"]}</regionId>
                </record>
            </clientRecords>";
    }
}