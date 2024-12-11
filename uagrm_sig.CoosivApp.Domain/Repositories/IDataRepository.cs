using uagrm_sig.CoosivApp.Domain.Common;
using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.Repositories;

public interface IDataRepository
{
    Task<List<ServiceRoute>> GetRoutes();
    Task<ServiceRoute> GetRouteDetails(ServiceRoute serviceRoute);
    Task<ServiceCut?> GetServiceCut(int routeId, int accountId);
    Task<ServiceCut?> SaveCutToServer(ServiceCut cut);
}