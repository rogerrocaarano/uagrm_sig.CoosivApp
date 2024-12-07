using System.Text.Json.Serialization;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

public class Route
{
    [JsonPropertyName("vehicle_id")] public string VehicleId { get; set; }
    [JsonPropertyName("distance")] public int Distance { get; set; }
    [JsonPropertyName("transport_time")] public int TransportTime { get; set; }
    [JsonPropertyName("completion_time")] public int CompletionTime { get; set; }
    [JsonPropertyName("waiting_time")] public int WaitingTime { get; set; }
    [JsonPropertyName("service_duration")] public int ServiceDuration { get; set; }
    [JsonPropertyName("preparation_time")] public int PreparationTime { get; set; }
    [JsonPropertyName("activities")] public List<Activity> Activities { get; set; }
}