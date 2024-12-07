using Scalar.AspNetCore;
using uagrm_sig.CoosivApp.Application.Services;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Domain.Services;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient;
using uagrm_sig.CoosivApp.Infrastructure.GraphHopperClient;

var builder = WebApplication.CreateBuilder(args);

// Load configuration and environment variables
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();



// Services

// Presentation Services
builder.Services.AddOpenApi();
builder.Services.AddControllers();


// Infrastructure services
// Coosiv Web Services Clients
builder.Services.AddHttpClient();
builder.Services.AddScoped<IDataRepository, CoosivWebService>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var baseUrl = builder.Configuration["InfrastructureServices:Coosiv:Data:BaseUrl"];
    var ns = builder.Configuration["InfrastructureServices:Coosiv:Data:Namespace"];
    if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(ns))
    {
        throw new InvalidOperationException("Coosiv configuration is missing");
    }

    return new CoosivWebService(httpClientFactory, baseUrl, ns);
});

// GraphHopper API Client
var graphHopperKey = builder.Configuration["InfrastructureServices:GraphHopper:ApiKey"];
if (string.IsNullOrWhiteSpace(graphHopperKey))
{
    throw new InvalidOperationException("GraphHopper ApiKey is missing");
}

builder.Services.AddScoped<IRouteOptimizer>(_ => new GraphHopperService(graphHopperKey));

builder.Services.AddScoped<RouteService>();
var app = builder.Build();



// Post build configuration
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options
        .WithTitle("Rest API SIG Cortes")
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();