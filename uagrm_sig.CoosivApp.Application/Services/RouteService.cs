using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Domain.UseCases;

namespace uagrm_sig.CoosivApp.Application.Services;

public class RouteService(IDataRepository dataRepository) : IGetRoute, IGetRoutes
{
    public async Task<ServiceRoute> GetRouteWithDetails(int id)
    {
        var route = new ServiceRoute
        {
            Id = id,
            ServiceAccounts = [],
            StartingPoint = new Point
            {
                Latitude = -16.379623,
                Longitude = -60.960682,
                Description = "COOSIV LTDA"
            }
        };
        var routeDetails = await dataRepository.GetRouteDetails(route);
        return routeDetails;
    }

    public async Task<List<int>> GetRoutesIds()
    {
        var routes = await dataRepository.GetRoutes();
        return routes.Select(route => route.Id).ToList();
    }

    public async Task<List<ServiceRoute>> GetRoutes()
    {
        var routesIds = await GetRoutesIds();
        var routes = new List<ServiceRoute>();
        foreach (var id in routesIds)
        {
            var route = await GetRouteWithDetails(id);
            routes.Add(route);
        }

        return routes;
    }
}