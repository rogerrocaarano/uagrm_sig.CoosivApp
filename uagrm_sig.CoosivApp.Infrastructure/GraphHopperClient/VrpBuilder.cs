using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient.Entities;

namespace uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;

public static class VrpBuilder
{
    private const int MaxServicesPerRequest = 20;

    public static VrpRequest BuildVrpRequest(ServiceRoute route, Point startingPoint)
    {
        var vrpRequest = new VrpRequest
        {
            Vehicles = [BuildVehicleObject(route, startingPoint)],
            Services = BuildServicesList(route),
            Objectives = [MinimumCompletionTimeObjective()]
        };
        return vrpRequest.Services.Count > MaxServicesPerRequest
            ? LimitVrpRequestSize(vrpRequest, MaxServicesPerRequest).First()
            : vrpRequest;
    }

    private static List<Service> BuildServicesList(ServiceRoute route)
    {
        return route.ServiceAccounts.Select(service => new Service
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
        }).ToList();
    }

    private static List<VrpRequest> LimitVrpRequestSize(VrpRequest vrpRequest, int maxServicesPerRequest)
    {
        var vrpRequests = new List<VrpRequest>();
        var services = vrpRequest.Services;
        var vehicles = vrpRequest.Vehicles;
        var servicesCount = services.Count;
        var requestsCount = (int)Math.Ceiling((double)servicesCount / maxServicesPerRequest);
        for (var i = 0; i < requestsCount; i++)
        {
            var servicesToInclude = services.Skip(i * maxServicesPerRequest).Take(maxServicesPerRequest).ToList();
            var vrpRequestToInclude = new VrpRequest
            {
                Services = servicesToInclude,
                Vehicles = vehicles,
                Objectives = vrpRequest.Objectives
            };
            vrpRequests.Add(vrpRequestToInclude);
        }

        return vrpRequests;
    }

    private static Vehicle BuildVehicleObject(ServiceRoute route, Point startingPoint)
    {
        return new Vehicle
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
        };
    }

    private static Objective MinimumCompletionTimeObjective()
    {
        return new Objective
        {
            Type = "min",
            Value = "completion_time"
        };
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