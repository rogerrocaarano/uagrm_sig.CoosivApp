namespace uagrm_sig.CoosivApp.Presentation.Api.ServiceConfiguration;

public static class PresentationServiceConfiguration
{
    public static void AddPresentationServices(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddControllers();
    }
}