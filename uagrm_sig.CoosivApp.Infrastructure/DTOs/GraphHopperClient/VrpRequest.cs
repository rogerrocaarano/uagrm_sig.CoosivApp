using System.Text.Json.Serialization;
using uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;

public class VrpRequest
{
    [JsonPropertyName("vehicles")] public List<Vehicle> Vehicles { get; set; }
    [JsonPropertyName("services")] public List<Service> Services { get; set; }
    [JsonPropertyName("objectives")] public List<Objective> Objectives { get; set; }
}