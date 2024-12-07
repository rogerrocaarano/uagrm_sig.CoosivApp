using System.Text.Json.Serialization;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

public class Address
{
    [JsonPropertyName("location_id")] public string LocationId { get; set; }
    [JsonPropertyName("lon")] public double Longitude { get; set; }
    [JsonPropertyName("lat")] public double Latitude { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
}