using System.Text.Json;
using uagrm_sig.CoosivApp.Domain.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.DTOs.Common;

public abstract class DtoSerializer
{
    public string Serialize()
    {
        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        return JsonSerializer.Serialize(this, serializerOptions);
    }
}