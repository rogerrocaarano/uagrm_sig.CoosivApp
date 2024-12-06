using System.Text.Json;
using uagrm_sig.CoosivApp.Domain.Common;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient.DTOs.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.DTOs.CoosivWebService;

public class ObtenerRutasResponseTable : DtoSerializer, IDto
{
    public List<ObtenerRutasResponseItem> Items { get; set; }
}