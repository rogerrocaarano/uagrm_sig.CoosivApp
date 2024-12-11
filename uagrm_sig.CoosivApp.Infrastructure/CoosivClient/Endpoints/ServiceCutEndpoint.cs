using uagrm_sig.CoosivApp.Infrastructure.CoosivClient.Parsers;
using uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.Endpoints;

public class ServiceCutEndpoint(SoapClient client)
{
    public async Task<W3Corte_UpdateCorteResponse> W3Corte_UpdateCorte(int LinCoc, int LinCemc, DateTime LdFcor, int LinPres, int LiCobc, int LiLcor, int LiNofn, string LsAppName)
    {
        var requestDto = new W3Corte_UpdateCorteRequest
        {
            LiNcoc = LinCoc,
            LiCemc = LinCemc,
            LdFcor = LdFcor,
            LiPres = LinPres,
            LiCobc = LiCobc,
            LiLcor = LiLcor,
            LiNofn = LiNofn,
            LsAppName = LsAppName
        };

        try
        {
            var response = await client.SendRequestAsync("W3Corte_UpdateCorte", requestDto.ToSoapBody());
            var xmlNodes = client.GetResponseNodes(response, "W3Corte_UpdateCorteResult");

            return new W3Corte_UpdateCorteResponse
            {
                response = (int)NumberParser.ParseNullableInt(xmlNodes[0]?.InnerText)!
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}