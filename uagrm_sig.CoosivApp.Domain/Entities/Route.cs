namespace uagrm_sig.CoosivApp.Domain.Entities;

public class Route
{
    public int Id { get; set; }
    public List<ServiceAccount> ServiceAccounts { get; set; }
}