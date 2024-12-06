using Moq;
using uagrm_sig.CoosivApp.Infrastructure.CoosivClient;
using Xunit.Abstractions;

namespace uagrm_sig.CoosivApp.Intrastructure.Tests;

public class CoosivWebServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly CoosivWebService _coosivWebService;

    public CoosivWebServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        var httpClient = new HttpClient();
        _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

        var baseUrl = "http://190.171.244.211:8080/wsVarios/wsBs.asmx";
        var ns = "http://tempuri.org/";
        _coosivWebService = new CoosivWebService(_httpClientFactoryMock.Object, baseUrl, ns);
    }

    [Fact]
    public async Task GetRoutes_ShouldReturnNotNull()
    {
        // Arrange
        // Configura el mock y los datos esperados aquí

        // Act
        var result = await _coosivWebService.GetRoutes();

        // Assert
        // Verifica que el resultado sea el esperado
        _testOutputHelper.WriteLine(result.Serialize());
        Assert.NotNull(result);
        Assert.Contains("items", result.Serialize());
    }
    
    [Fact]
    public async Task GetRouteById_ShouldReturnNotNull()
    {
        // Arrange
        // Configura el mock y los datos esperados aquí
    
        // Act
        var result = await _coosivWebService.GetRouteById(75);
    
        // Assert
        // Verifica que el resultado sea el esperado
        _testOutputHelper.WriteLine(result.Serialize());
        Assert.NotNull(result);
        Assert.Contains("items", result.Serialize());
    }
}