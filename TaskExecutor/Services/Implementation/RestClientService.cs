using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace TaskExecutor.Services.Implementation;

public class RestClientService
{
    public async Task ExecuteTask(string url)
    {
        var client = new RestClient(url);
        var contentRequest = new RestRequest();
        contentRequest.AddHeader("cache-control", "no-cache");
        contentRequest.AddHeader("Content-Type", "application/json");
        
        contentRequest.RequestFormat = DataFormat.Json;
        contentRequest.AddJsonBody(JsonConvert.SerializeObject(data, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        return await client.ExecutePostAsync(contentRequest);
    }
}