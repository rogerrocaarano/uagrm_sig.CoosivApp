using uagrm_sig.CoosivApp.Infrastructure.DTOs.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

/// <summary>
/// W0Corte_ObtenerRutas
/// http://190.171.244.211:8080/wsVarios/wsBs.asmx?op=W0Corte_ObtenerRutas
/// </summary>
public class ObtenerRutasRequestDto : ISoapRequest
{
    public int LiCper { get; set; } // ??? enviar 0 para obtener toda la lista

    public string ToSoapBody()
    {
        return $@"<W0Corte_ObtenerRutas xmlns=""http://activebs.net/"">
                      <liCper>{LiCper}</liCper>
                  </W0Corte_ObtenerRutas>";
    }
}