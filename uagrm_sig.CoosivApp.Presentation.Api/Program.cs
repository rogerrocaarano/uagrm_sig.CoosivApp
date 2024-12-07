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

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

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

var graphHopperKey = builder.Configuration["InfrastructureServices:GraphHopper:ApiKey"];
if (string.IsNullOrWhiteSpace(graphHopperKey))
{
    throw new InvalidOperationException("GraphHopper ApiKey is missing");
}

builder.Services.AddScoped<IRouteOptimizer>(_ => new GraphHopperService(graphHopperKey));

builder.Services.AddScoped<RouteService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();