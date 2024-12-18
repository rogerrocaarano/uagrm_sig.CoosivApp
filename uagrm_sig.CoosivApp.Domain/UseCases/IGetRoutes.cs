﻿using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.UseCases;

public interface IGetRoutes
{
    Task<List<ServiceRoute>> GetRoutes();
}