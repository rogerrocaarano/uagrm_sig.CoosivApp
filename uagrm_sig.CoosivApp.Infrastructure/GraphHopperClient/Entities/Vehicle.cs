using System.Text.Json.Serialization;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

public class Vehicle
{
    [JsonPropertyName("vehicle_id")] public string VehicleId { get; set; }
    [JsonPropertyName("start_address")] public Address StartAddress { get; set; }
    [JsonPropertyName("return_to_depot")] public bool ReturnToDepot { get; set; }
}