using System.Text.Json.Serialization;
using uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;

public class VrpResponse
{
    [JsonPropertyName("job_id")] public string JobId { get; set; }
    [JsonPropertyName("status")] public string Status { get; set; }
    [JsonPropertyName("waiting_time_in_queue")] public int WaitingTime { get; set; }
    [JsonPropertyName("processing_time")] public int ProcessingTime { get; set; }
    [JsonPropertyName("solution")] public Solution Solution { get; set; }
}