using Scalar.AspNetCore;
using uagrm_sig.CoosivApp.Presentation.Api.ServiceConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Services
builder.Services.AddPresentationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

// App building
var app = builder.Build();
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