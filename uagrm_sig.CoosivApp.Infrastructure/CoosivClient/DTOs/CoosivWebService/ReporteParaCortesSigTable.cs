﻿using System.Text.Json;
using uagrm_sig.CoosivApp.Domain.Common;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient.DTOs.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient.DTOs.CoosivWebService;

public class ReporteParaCortesSigTable : IDto
{
    public List<ReporteParaCortesSigItem> Items { get; set; }
    public string Serialize()
    {
        return DtoSerializer.Serialize(this);
    }
}