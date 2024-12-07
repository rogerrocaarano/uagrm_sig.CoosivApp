using uagrm_sig.CoosivApp.Domain.Common;
using uagrm_sig.CoosivApp.Infrastructure.DTOs.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

public class ObtenerRutasResponseTable : IDto
{
    public List<ObtenerRutasResponseItem> Items { get; set; }
    public string Serialize()
    {
        return DtoSerializer.Serialize(this);
    }
}