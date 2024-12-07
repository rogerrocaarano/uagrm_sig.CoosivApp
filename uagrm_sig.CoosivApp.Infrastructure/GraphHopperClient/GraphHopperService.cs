using System.Text.Json;
using RestSharp;
using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Services;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;

public class GraphHopperService : IRouteOptimizer
{
    private readonly RestClient _client;
    private const string BaseUrl = "https://graphhopper.com/api/1";

    public GraphHopperService(string apiKey)
    {
        _client = new RestClient(BaseUrl);
        _client.AddDefaultQueryParameter("key", apiKey);
    }

    private async Task<RestResponse> PostAsync(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(body);
        request.AddHeader("Content-Type", "application/json");
        return await _client.ExecuteAsync(request);
    }

    public ServiceRoute GetOptimizedRoute(ServiceRoute serviceRoute, Point startingPoint)
    {
        var vrpRequest = VrpBuilder.BuildVrpRequest(serviceRoute, startingPoint);
        var jsonVrpResponse = PostAsync("/vrp", vrpRequest).Result.Content;
        var vrpResponse = JsonSerializer.Deserialize<VrpResponse>(jsonVrpResponse);
        return VrpBuilder.SortRoute(serviceRoute, vrpResponse);
    }
}