using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Presentation.Api.DTOs.Auth;

public class PostLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public User ToUser()
    {
        return new User
        {
            Username = Username,
            Password = Password
        };
    }
}