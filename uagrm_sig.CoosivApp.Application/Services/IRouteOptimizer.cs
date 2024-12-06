using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Application.Services;

public interface IRouteOptimizer
{
    Route GetOptimizedRoute(Route route, Point startingPoint);
}