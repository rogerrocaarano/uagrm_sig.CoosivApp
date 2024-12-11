namespace uagrm_sig.CoosivApp.Domain.Entities;

public class ServiceCut
{
    public int Id { get; set; }
    public ServiceAccount Account { get; set; }
    public DateTime? CutDate { get; set; }
    public string? Status { get; set; }
}