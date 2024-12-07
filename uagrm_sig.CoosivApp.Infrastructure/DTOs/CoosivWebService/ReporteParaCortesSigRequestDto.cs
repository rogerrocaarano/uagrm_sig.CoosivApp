namespace uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

public class ReporteParaCortesSigRequestDto
{
    public int liNrut { get; set; }

    public int liNcnt { get; set; }

    public int liCper { get; set; }

    public string ToSoapBody()
    {
        return $@"<W2Corte_ReporteParaCortesSIG xmlns=""http://activebs.net/"">
                      <liNrut>{liNrut}</liNrut>
                      <liNcnt>{liNcnt}</liNcnt>
                      <liCper>{liCper}</liCper>
                   </W2Corte_ReporteParaCortesSIG>";
    }
}