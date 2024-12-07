namespace uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;
/// <summary>
/// Extraido de W0Corte_ObtenerRutas
/// http://190.171.244.211:8080/wsVarios/wsBs.asmx?op=W0Corte_ObtenerRutas
/// </summary>
public class ObtenerRutasResponseItem
{
    public int? bsrutnrut { get; set; } // Número de ruta
    public string? bsrutdesc { get; set; } // Descripción de la ruta
    public string? bsrutabrv { get; set; } // Abreviatura de la ruta
    public int? bsruttipo { get; set; } // Tipo de ruta
    public int? bsrutnzon { get; set; } // Número de zona
    public string? bsrutfcor { get; set; } // Fecha de corte
    public int? bsrutcper { get; set; } // Código de persona
    public int? bsrutstat { get; set; } // Estado de la ruta
    public int? bsrutride { get; set; } // ???
    public string? dNomb { get; set; } // Nombre
    public int? GbzonNzon { get; set; } // Número de zona
    public string? dNzon { get; set; } // Descripción de zona
}