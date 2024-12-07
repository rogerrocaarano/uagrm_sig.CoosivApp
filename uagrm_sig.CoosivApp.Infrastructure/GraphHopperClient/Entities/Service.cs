using System.Text.Json.Serialization;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

public class Service
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("priority")] public int Priority { get; set; }
    [JsonPropertyName("address")] public Address Address { get; set; }
    [JsonPropertyName("duration")] public int Duration { get; set; }
    [JsonPropertyName("preparation_time")] public int PreparationTime { get; set; }
}