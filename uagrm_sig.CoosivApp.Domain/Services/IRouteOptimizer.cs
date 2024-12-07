using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.Services;

public interface IRouteOptimizer
{
    ServiceRoute GetOptimizedRoute(ServiceRoute serviceRoute, Point startingPoint);
}