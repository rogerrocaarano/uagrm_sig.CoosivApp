using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.UseCases;

public interface ILogin
{
    User? ValidateUser(User user);
    User? SetAuthToken(User user);
}