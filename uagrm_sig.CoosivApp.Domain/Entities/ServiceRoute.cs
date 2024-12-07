namespace uagrm_sig.CoosivApp.Domain.Entities;

public class ServiceRoute
{
    public int Id { get; set; }
    public List<ServiceAccount> ServiceAccounts { get; set; }
    public Point? StartingPoint { get; set; }
    public string? Name { get; set; }
}