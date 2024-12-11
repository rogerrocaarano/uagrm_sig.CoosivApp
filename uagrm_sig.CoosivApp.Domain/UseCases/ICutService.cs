using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.UseCases;

public interface ICutService
{
    Task<ServiceCut?> GetServiceCut(int routeId, int accountId);
    Task<ServiceCut> SaveCutToServer(ServiceCut cut);
}