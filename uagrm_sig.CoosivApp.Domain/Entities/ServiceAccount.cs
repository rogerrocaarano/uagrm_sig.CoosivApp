namespace uagrm_sig.CoosivApp.Domain.Entities;

public class ServiceAccount
{
    public int AccountNumber { get; set; }
    public string Name { get; set; }
    public Point Address { get; set; }
    public string? Notes { get; set; }
    public string? Category { get; set; }
}