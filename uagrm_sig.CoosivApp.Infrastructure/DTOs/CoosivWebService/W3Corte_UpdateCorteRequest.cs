using uagrm_sig.CoosivApp.Infrastructure.DTOs.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

public class W3Corte_UpdateCorteRequest : ISoapRequest
{
    public int LiNcoc { get; set; }
    public int LiCemc { get; set; }
    public DateTime LdFcor { get; set; }
    public int LiPres { get; set; }
    public int LiCobc { get; set; }
    public int LiLcor { get; set; }
    public int LiNofn { get; set; }
    public string LsAppName { get; set; }
    
    public string ToSoapBody()
    {
        throw new NotImplementedException();
    }
}