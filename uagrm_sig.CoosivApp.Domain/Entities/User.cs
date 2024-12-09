namespace uagrm_sig.CoosivApp.Domain.Entities;

public class User
{
    public int? Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? AuthToken { get; set; }
}