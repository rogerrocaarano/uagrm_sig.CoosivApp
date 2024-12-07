using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;

public static class VrpBuilder
{
    public static VrpRequest BuildVrpRequest(ServiceRoute route, Point startingPoint)
    {
        var vrpRequest = new VrpRequest
        {
            Vehicles =
            [
                new Vehicle
                {
                    VehicleId = $"vehicle_route_{route.Id}",
                    StartAddress = new Address
                    {
                        LocationId = "start",
                        Longitude = startingPoint.Longitude,
                        Latitude = startingPoint.Latitude,
                        Name = startingPoint.Description
                    },
                    ReturnToDepot = true
                }
            ],
            Services = route.ServiceAccounts.Select(service => new Service
            {
                Id = $"{service.AccountNumber}",
                Type = "service",
                Priority = 2,
                Address = new Address
                {
                    LocationId = $"{service.AccountNumber}",
                    Longitude = service.Address.Longitude,
                    Latitude = service.Address.Latitude,
                    Name = service.Name
                },
                Duration = 600,
                PreparationTime = 0
            }).ToList(),
            Objectives =
            [
                new Objective
                {
                    Type = "min",
                    Value = "completion_time"
                }
            ]
        };
        return vrpRequest;
    }
    
    public static ServiceRoute SortRoute(ServiceRoute serviceRoute, VrpResponse vrpResponse)
    {
        var sortedServices = vrpResponse.Solution.Routes.First().Activities
            .Where(activity => activity.Type == "service")
            .Select(activity => serviceRoute.ServiceAccounts.First(service =>
                service.AccountNumber == int.Parse(activity.Id))
            ).ToList();
        serviceRoute.ServiceAccounts = sortedServices;
        return serviceRoute;
    }
}