using System.Xml;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient.Parsers;
using uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;
namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.Endpoints;

public class RoutesEndpoint(SoapClient client)
{
    public async Task<ObtenerRutasResponseTable> W0Corte_ObtenerRutas(int LiCper)
    {
        var requestDto = new ObtenerRutasRequestDto
        {
            LiCper = LiCper
        };
        try
        {
            var response = await client.SendRequestAsync("W0Corte_ObtenerRutas", requestDto.ToSoapBody());
            var xmlNodes = client.GetResponseNodes(response, "Table");

            var responseItems = (from XmlNode node in xmlNodes
                select new ObtenerRutasResponseItem
                {
                    bsrutnrut = NumberParser.ParseNullableInt(node["bsrutnrut"]?.InnerText),
                    bsrutdesc = node["bsrutdesc"]?.InnerText?.Trim(),
                    bsrutabrv = node["bsrutabrv"]?.InnerText?.Trim(),
                    bsruttipo = NumberParser.ParseNullableInt(node["bsruttipo"]?.InnerText),
                    bsrutnzon = NumberParser.ParseNullableInt(node["bsrutnzon"]?.InnerText),
                    bsrutfcor = node["bsrutfcor"]?.InnerText?.Trim(),
                    bsrutcper = NumberParser.ParseNullableInt(node["bsrutcper"]?.InnerText),
                    bsrutstat = NumberParser.ParseNullableInt(node["bsrutstat"]?.InnerText),
                    bsrutride = NumberParser.ParseNullableInt(node["bsrutride"]?.InnerText),
                    dNomb = node["dNomb"]?.InnerText?.Trim(),
                    GbzonNzon = NumberParser.ParseNullableInt(node["GbzonNzon"]?.InnerText),
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
    
    public async Task<ReporteParaCortesSigTable> W0Corte_ReporteParaCortesSIG(int liNrut, int liCper, int liNcnt)
    {
        var requestDto = new ReporteParaCortesSigRequestDto
        {
            liNrut = liNrut,
            liCper = liCper,
            liNcnt = liNcnt
        };

        try
        {
            var response = await client.SendRequestAsync("W0Corte_ReporteParaCortesSIG", requestDto.ToSoapBody());
            var xmlNodes = client.GetResponseNodes(response, "Table");

            var responseItems = (from XmlNode node in xmlNodes
                select new ReporteParaCortesSigItem
                {
                    bscocNcoc = NumberParser.ParseNullableInt(node["bscocNcoc"]?.InnerText),
                    bscntCodf = NumberParser.ParseNullableInt(node["bscntCodf"]?.InnerText),
                    bscocNcnt = NumberParser.ParseNullableInt(node["bscocNcnt"]?.InnerText),
                    dNomb = node["dNomb"]?.InnerText.Trim(),
                    bscocNmor = NumberParser.ParseNullableInt(node["bscocNmor"]?.InnerText),
                    bscocImor = NumberParser.ParseNullableDecimal(node["bscocImor"]?.InnerText),
                    bsmednser = node["bsmednser"]?.InnerText.Trim(),
                    bsmedNume = node["bsmedNume"]?.InnerText.Trim(),
                    bscntlati = NumberParser.ParseNullableDecimal(node["bscntlati"]?.InnerText),
                    bscntlogi = NumberParser.ParseNullableDecimal(node["bscntlogi"]?.InnerText),
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
}