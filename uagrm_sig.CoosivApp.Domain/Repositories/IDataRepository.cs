using uagrm_sig.CoosivApp.Domain.Common;
using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.Repositories;

public interface IDataRepository
{
    Task<List<Route>> GetRoutes();
    Task<Route> GetRouteDetails(Route route);
}