using uagrm_sig.CoosivApp.Domain.Common;

namespace uagrm_sig.CoosivApp.Domain.Repositories;

public interface IDataRepository
{
    Task<IDto> GetRoutes();
    Task<IDto> GetRouteById(int id);
}