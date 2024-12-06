using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.UseCases;

public interface IGetRoute
{
    Task<Route> GetRouteWithDetails(int id);
}