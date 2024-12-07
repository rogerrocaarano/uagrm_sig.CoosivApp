using System.Text.Json.Serialization;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

public class Objective
{
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("value")] public string Value { get; set; }
}