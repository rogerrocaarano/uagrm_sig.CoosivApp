using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient.Endpoints;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient;

public class CoosivWebService : IDataRepository
{
    private readonly RoutesEndpoint _routesEndpoint;
    private readonly ServiceCutEndpoint _serviceCutEndpoint;

    public CoosivWebService(IHttpClientFactory httpClientFactory, string baseUrl, string ns)
    {
        var soapClient = new SoapClient(httpClientFactory, baseUrl, ns);
        _routesEndpoint = new RoutesEndpoint(soapClient);
        _serviceCutEndpoint = new ServiceCutEndpoint(soapClient);
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

    public async Task<ServiceCut?> GetServiceCut(int routeId, int accountId)
    {
        var dto = await _routesEndpoint.W0Corte_ReporteParaCortesSIG(routeId, 0, accountId);
        if (dto.Items.Count == 0)
        {
            return null;
        }

        if (dto.Items.Count > 1)
        {
            throw new Exception("More than one record found");
        }

        var i = dto.Items[0];
        return new ServiceCut
        {
            Id = (int)i.bscocNcoc!,
            Account = new ServiceAccount
            {
                AccountNumber = accountId,
                Address = new Point
                {
                    Latitude = (double)i.bscntlati!,
                    Longitude = (double)i.bscntlogi!
                },
                Category = i.dNcat!,
                Name = i.dNomb!,
                Notes = i.dCobc
            }
        };
    }

    public async Task<ServiceCut?> SaveCutToServer(ServiceCut cut)
    {
        var dto = await _serviceCutEndpoint.W3Corte_UpdateCorte(
            cut.Id,
            0,
            DateTime.Now,
            0,
            0,
            0,
            0,
            "CoosivApp Backend");
        return dto.response == 1 ? cut : null;
    }
}