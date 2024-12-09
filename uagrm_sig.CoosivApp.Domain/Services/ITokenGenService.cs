using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.Services;

public interface ITokenGenService
{
    string GenerateToken(User user);
}