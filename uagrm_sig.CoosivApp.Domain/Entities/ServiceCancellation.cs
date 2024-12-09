namespace uagrm_sig.CoosivApp.Domain.Entities;

public class ServiceCancellation
{
    public ServiceAccount ServiceAccount { get; set; }
    public bool CancellationCompleted { get; set; }
    public DateTime TimeOfCancellation { get; set; }
    public string? Observation { get; set; }
}