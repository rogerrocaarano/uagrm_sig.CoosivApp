using uagrm_sig.CoosivApp.Domain.Entities;

namespace uagrm_sig.CoosivApp.Domain.UseCases;

public interface IPostServiceCancellation
{
    Task PostServiceCancellation(List<ServiceCancellation> serviceCancellationReport);
}