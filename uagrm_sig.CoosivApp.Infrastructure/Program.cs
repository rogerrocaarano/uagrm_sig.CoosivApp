// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using uagrm_sig.CoosivApp.Domain.Repositories;
// using uagrm_sig.CoosivApp.Infrastructure.CoosivClient;
//
// namespace uagrm_sig.CoosivApp.Infrastructure;
//
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var host = CreateHostBuilder(args).Build();
//         host.Run();
//     }
//
//     public static IHostBuilder CreateHostBuilder(string[] args) =>
//         Host.CreateDefaultBuilder(args)
//             .ConfigureServices((hostContext, services) =>
//             {
//                 services.AddHttpClient();
//                 services.AddScoped<IDataRepository, CoosivWebService>(provider =>
//                 {
//                     var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
//                     var baseUrl = "http://190.171.244.211:8080/wsVarios/wsBs.asmx";
//                     var ns = "http://tempuri.org/";
//                     return new CoosivWebService(httpClientFactory, baseUrl, ns);
//                 });
//             });
// }