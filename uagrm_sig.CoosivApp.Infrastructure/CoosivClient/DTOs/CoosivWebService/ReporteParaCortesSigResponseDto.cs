namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.DTOs.CoosivWebService;

public class ReporteParaCortesSigResponseDto
{
    public int? bscocNcoc { get; set; }
    public int? bscntCodf { get; set; }
    public int? bscocNcnt { get; set; }
    public string? dNomb { get; set; }
    public int? bscocNmor { get; set; }
    public decimal? bscocImor { get; set; }
    public string? bsmednser { get; set; }
    public string? bsmedNume { get; set; }
    public decimal? bscntlati { get; set; }
    public decimal? bscntlogi { get; set; }
    public string? dNcat { get; set; }
    public string? dCobc { get; set; }
    public string? dLotes { get; set; }
    
    public bool HasNonZeroCoordinates()
    {
        return bscntlati != 0 && bscntlogi != 0;
    }
}

