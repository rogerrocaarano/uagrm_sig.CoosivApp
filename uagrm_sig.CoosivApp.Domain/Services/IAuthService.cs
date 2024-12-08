using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.Services;

public interface IAuthService
{
    string CreateToken(User user);
}