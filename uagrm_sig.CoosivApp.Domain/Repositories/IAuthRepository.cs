using uagrm_sig.CoosivApp.Domain.Common;
using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.Repositories;

public interface IAuthRepository
{
    Task<IDto> ValidateLogin(IDto request);
}