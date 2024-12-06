using System.Text.Json;
using uagrm_sig.CoosivApp.Domain.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.DTOs.Common;

public static class DtoSerializer
{
    public static string Serialize<T>(T dto) where T : IDto
    {
        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        return JsonSerializer.Serialize(dto, serializerOptions);
    }
}