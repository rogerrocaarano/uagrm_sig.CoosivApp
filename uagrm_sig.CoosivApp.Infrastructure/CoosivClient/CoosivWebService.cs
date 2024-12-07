using System.Xml;
using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient;

public class CoosivWebService(IHttpClientFactory httpClientFactory, string baseUrl, string ns)
    : SoapClient(httpClientFactory, baseUrl, ns), IDataRepository
{
    public async Task<ObtenerRutasResponseTable> GetRoutesDto()
    {
        var requestDto = new ObtenerRutasRequestDto
        {
            LiCper = 0
        };
        try
        {
            var response = await SendRequestAsync("W0Corte_ObtenerRutas", requestDto.ToSoapBody());
            var xmlNodes = GetResponseNodes(response, "Table");

            var responseItems = (from XmlNode node in xmlNodes
                select new ObtenerRutasResponseItem
                {
                    bsrutnrut = ParseNullableInt(node["bsrutnrut"]?.InnerText),
                    bsrutdesc = node["bsrutdesc"]?.InnerText?.Trim(),
                    bsrutabrv = node["bsrutabrv"]?.InnerText?.Trim(),
                    bsruttipo = ParseNullableInt(node["bsruttipo"]?.InnerText),
                    bsrutnzon = ParseNullableInt(node["bsrutnzon"]?.InnerText),
                    bsrutfcor = node["bsrutfcor"]?.InnerText?.Trim(),
                    bsrutcper = ParseNullableInt(node["bsrutcper"]?.InnerText),
                    bsrutstat = ParseNullableInt(node["bsrutstat"]?.InnerText),
                    bsrutride = ParseNullableInt(node["bsrutride"]?.InnerText),
                    dNomb = node["dNomb"]?.InnerText?.Trim(),
                    GbzonNzon = ParseNullableInt(node["GbzonNzon"]?.InnerText),
                    dNzon = node["dNzon"]?.InnerText?.Trim()
                }).ToList();

            return new ObtenerRutasResponseTable
            {
                Items = responseItems
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ReporteParaCortesSigTable> GetRouteDtoById(int id)
    {
        var requestDto = new ReporteParaCortesSigRequestDto
        {
            liNrut = id,
            liCper = 0,
            liNcnt = 0
        };

        try
        {
            var response = await SendRequestAsync("W0Corte_ReporteParaCortesSIG", requestDto.ToSoapBody());
            var xmlNodes = GetResponseNodes(response, "Table");

            var responseItems = (from XmlNode node in xmlNodes
                select new ReporteParaCortesSigItem
                {
                    bscocNcoc = ParseNullableInt(node["bscocNcoc"]?.InnerText),
                    bscntCodf = ParseNullableInt(node["bscntCodf"]?.InnerText),
                    bscocNcnt = ParseNullableInt(node["bscocNcnt"]?.InnerText),
                    dNomb = node["dNomb"]?.InnerText.Trim(),
                    bscocNmor = ParseNullableInt(node["bscocNmor"]?.InnerText),
                    bscocImor = ParseNullableDecimal(node["bscocImor"]?.InnerText),
                    bsmednser = node["bsmednser"]?.InnerText.Trim(),
                    bsmedNume = node["bsmedNume"]?.InnerText.Trim(),
                    bscntlati = ParseNullableDecimal(node["bscntlati"]?.InnerText),
                    bscntlogi = ParseNullableDecimal(node["bscntlogi"]?.InnerText),
                    dNcat = node["dNcat"]?.InnerText.Trim(),
                    dCobc = node["dCobc"]?.InnerText.Trim(),
                    dLotes = node["dLotes"]?.InnerText.Trim()
                }).ToList();

            return new ReporteParaCortesSigTable
            {
                Items = responseItems
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Route>> GetRoutes()
    {
        var dto = await GetRoutesDto();
        return dto.Items.Select(i => new Route { Id = (int)i.bsrutnrut!, ServiceAccounts = [] }).ToList();
    }

    public async Task<Route> GetRouteDetails(Route route)
    {
        var dto = await GetRouteDtoById(route.Id);
        route.ServiceAccounts = dto.Items.Select(i => new ServiceAccount
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
        return route;
    }
}