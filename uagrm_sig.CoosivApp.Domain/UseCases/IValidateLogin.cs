using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.UseCases;

public interface IValidateLogin
{
    Task<bool> LoginIsValid(LoginCredentials loginCredentials);
}