using uagrm_sig.CoosivApp.Application.Validators;
using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Domain.Services;
using uagrm_sig.CoosivApp.Domain.UseCases;

namespace uagrm_sig.CoosivApp.Application.Services;

public class DataService(IDataRepository dataRepository, IRouteOptimizer routeOptimizer) : IGetRoute, IGetRoutes, ICutService
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
        RemoveInvalidPoints(routeDetails);
        var optimizedRoute = routeOptimizer.GetOptimizedRoute(routeDetails, route.StartingPoint);
        return optimizedRoute;
    }

    private static void RemoveInvalidPoints(ServiceRoute routeDetails)
    {
        foreach (var account in routeDetails.ServiceAccounts.ToList())
        {
            if (!PointValidator.IsValidPoint(account.Address))
            {
                routeDetails.ServiceAccounts.Remove(account);
            }
        }
    }

    public async Task<List<int>> GetRoutesIds()
    {
        var routes = await dataRepository.GetRoutes();
        return routes.Select(route => route.Id).ToList();
    }

    public async Task<List<ServiceRoute>> GetRoutes()
    {
        return await dataRepository.GetRoutes();
    }

    public async Task<ServiceCut?> GetServiceCut(int routeId, int accountId)
    {
        try
        {
            var cut = await dataRepository.GetServiceCut(routeId, accountId);
            return cut;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceCut?> SaveCutToServer(ServiceCut cut)
    {
        try
        {
            return await dataRepository.SaveCutToServer(cut);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}