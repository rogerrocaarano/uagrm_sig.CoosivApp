using uagrm_sig.CoosivApp.Infrastructure.DTOs.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

public class W3Corte_UpdateCorteRequest : ISoapRequest
{
    public int LiNcoc { get; set; } // Número de corte
    public int LiCemc { get; set; } // Código empleado que realiza el corte
    public DateTime LdFcor { get; set; } // Fecha del corte
    public int LiPres { get; set; } // Código grupo observación
    public int LiCobc { get; set; } // Código de observación
    public int LiLcor { get; set; } // ???
    public int LiNofn { get; set; } // Código de oficina
    public string LsAppName { get; set; } // Nombre de la aplicación
    
    public string ToSoapBody()
    {
        throw new NotImplementedException();
    }
}