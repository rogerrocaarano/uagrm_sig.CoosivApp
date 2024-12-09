using uagrm_sig.CoosivApp.Application.Services;

namespace uagrm_sig.CoosivApp.Presentation.Api.ServiceConfiguration;

public static class ApplicationServicesConfiguration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<RouteService>();
        services.AddScoped<AuthenticationService>();
    }
}