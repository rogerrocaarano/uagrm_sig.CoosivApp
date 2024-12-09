namespace uagrm_sig.CoosivApp.Domain.Repositories;

public interface IAuthRepository
{
    Task<int> GetUserId(string user, string password);
}