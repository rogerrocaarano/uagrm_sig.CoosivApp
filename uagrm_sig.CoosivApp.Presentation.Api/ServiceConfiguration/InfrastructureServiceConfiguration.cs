using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Domain.Services;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient;
using uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;

namespace uagrm_sig.CoosivApp.Presentation.Api.ServiceConfiguration;

public static class InfrastructureServiceConfiguration
{
    public static void AddCoosivDataService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddScoped<IDataRepository, CoosivWebService>(provider =>
        {
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var baseUrl = configuration["InfrastructureServices:Coosiv:Data:BaseUrl"];
            var ns = configuration["InfrastructureServices:Coosiv:Data:Namespace"];
            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(ns))
            {
                throw new InvalidOperationException("Coosiv configuration is missing");
            }

            return new CoosivWebService(httpClientFactory, baseUrl, ns);
        });
    }
    
    public static void AddGraphHopperService(this IServiceCollection services, IConfiguration configuration)
    {
        var graphHopperKey = configuration["InfrastructureServices:GraphHopper:ApiKey"];
        if (string.IsNullOrWhiteSpace(graphHopperKey))
        {
            throw new InvalidOperationException("GraphHopper ApiKey is missing");
        }

        services.AddScoped<IRouteOptimizer>(_ => new GraphHopperService(graphHopperKey));
    }
    
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCoosivDataService(configuration);
        services.AddGraphHopperService(configuration);
    }
}