using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Domain.Services;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient;
using uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;
using uagrm_sig.CoosivApp.Infrastructure.JwtBearer;

namespace uagrm_sig.CoosivApp.Presentation.Api.ServiceConfiguration;

public static class InfrastructureServiceConfiguration
{
    private static void AddCoosivDataService(this IServiceCollection services, IConfiguration configuration)
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

    private static void AddGraphHopperService(this IServiceCollection services, IConfiguration configuration)
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
        services.AddAuthenticationService(configuration);
    }

    private static void AddAuthenticationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IAuthService, AuthService>(_ =>
        {
            var privateKey = configuration["InfrastructureServices:Jwt:PrivateKey"];
            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw new InvalidOperationException("Jwt PrivateKey is missing");
            }

            return new AuthService(privateKey);
        });


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["InfrastructureServices:Jwt:PrivateKey"])),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
    }
}