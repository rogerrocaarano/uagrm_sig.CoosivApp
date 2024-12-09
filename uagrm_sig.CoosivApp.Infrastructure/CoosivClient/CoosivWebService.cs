using System.Xml;
using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient.Endpoints;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient;

public class CoosivWebService : IDataRepository
{
    private readonly RoutesEndpoint _routesEndpoint;

    public CoosivWebService(IHttpClientFactory httpClientFactory, string baseUrl, string ns)
    {
        var soapClient = new SoapClient(httpClientFactory, baseUrl, ns);
        _routesEndpoint = new RoutesEndpoint(soapClient);
    }

    public async Task<List<ServiceRoute>> GetRoutes()
    {
        var dto = await _routesEndpoint.W0Corte_ObtenerRutas(0);
        return dto.Items.Select(i => new ServiceRoute
        {
            Id = (int)i.bsrutnrut!,
            ServiceAccounts = [],
            Name = i.dNomb
        }).ToList();
    }

    public async Task<ServiceRoute> GetRouteDetails(ServiceRoute serviceRoute)
    {
        var dto = await _routesEndpoint.W0Corte_ReporteParaCortesSIG(serviceRoute.Id, 0, 0);
        serviceRoute.ServiceAccounts = dto.Items.Select(i => new ServiceAccount
        {
            AccountNumber = (int)i.bscocNcnt!,
            Address = new Point
            {
                Latitude = (double)i.bscntlati!,
                Longitude = (double)i.bscntlogi!
            },
            Category = i.dNcat!,
            Name = i.dNomb!,
            Notes = i.dCobc
        }).ToList();
        return serviceRoute;
    }
}