using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.UseCases;

public interface IGetRoute
{
    Task<ServiceRoute> GetRouteWithDetails(int id);
}