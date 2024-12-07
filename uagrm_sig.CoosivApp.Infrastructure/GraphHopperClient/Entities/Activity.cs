using System.Text.Json.Serialization;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

public class Activity
{
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("location_id")] public string LocationId { get; set; }
    [JsonPropertyName("address")] public Address Address { get; set; }
    [JsonPropertyName("arr_time")] public int ArrivalTime { get; set; }
    [JsonPropertyName("end_time")] public int EndTime { get; set; }
    [JsonPropertyName("end_date_time")] public string EndDateTime { get; set; }
    [JsonPropertyName("arr_date_time")] public string ArrivalDateTime { get; set; }
    [JsonPropertyName("waiting_time")] public int WaitingTime { get; set; }
    [JsonPropertyName("preparation_time")] public int PreparationTime { get; set; }
    [JsonPropertyName("distance")] public int Distance { get; set; }
    [JsonPropertyName("driving_time")] public int DrivingTime { get; set; }
    [JsonPropertyName("load_before")] public int[] LoadBefore { get; set; }
    [JsonPropertyName("load_after")] public int[] LoadAfter { get; set; }
}