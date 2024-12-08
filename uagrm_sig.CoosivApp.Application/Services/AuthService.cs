using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Domain.Services;
using uagrm_sig.CoosivApp.Domain.UseCases;

namespace uagrm_sig.CoosivApp.Application.Services;

public class AuthService(IAuthRepository authRepository, ITokenGenService tokenGenService) : ILogin
{
    public User? ValidateUser(User user)
    {
        if (user.Username == null || user.Password == null)
        {
            return null;
        }

        var userId = authRepository.GetUserId(user.Username, user.Password).Result;
        if (userId == 0)
        {
            return null;
        }

        user.Id = userId;
        return user;
    }

    public User? SetAuthToken(User user)
    {
        if (user.Id == null)
        {
            return null;
        }

        user.AuthToken = tokenGenService.GenerateToken(user);
        return user;
    }
}