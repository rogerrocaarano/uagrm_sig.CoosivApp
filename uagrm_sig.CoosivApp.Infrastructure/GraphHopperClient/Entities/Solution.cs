using System.Text.Json.Serialization;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

public class Solution
{
    [JsonPropertyName("distance")] public int Distance { get; set; }
    [JsonPropertyName("transport_time")] public int TransportTime { get; set; }
    [JsonPropertyName("max_operation_time")] public int MaxOperationTime { get; set; }
    [JsonPropertyName("waiting_time")] public int WaitingTime { get; set; }
    [JsonPropertyName("preparation_time")] public int PreparationTime { get; set; }
    [JsonPropertyName("completion_time")] public int CompletionTime { get; set; }
    [JsonPropertyName("no_vehicles")] public int NoVehicles { get; set; }
    [JsonPropertyName("no_unassigned")] public int NoUnassigned { get; set; }
    [JsonPropertyName("routes")] public List<Route> Routes { get; set; }
    
}