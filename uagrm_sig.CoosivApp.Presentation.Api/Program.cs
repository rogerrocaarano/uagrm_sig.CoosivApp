using uagrm_sig.CoosivApp.Application.Services;
using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IDataRepository, CoosivWebService>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var baseUrl = "http://190.171.244.211:8080/wsVarios/wsBs.asmx";
    var ns = "http://tempuri.org/";
    return new CoosivWebService(httpClientFactory, baseUrl, ns);
});

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