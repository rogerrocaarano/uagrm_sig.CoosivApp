using uagrm_sig.CoosivApp.Domain.Repositories;
using uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient;

public class CoosivAuthService(IHttpClientFactory httpClientFactory, string baseUrl, string ns)
    : SoapClient(httpClientFactory, baseUrl, ns), IAuthRepository
{
    public async Task<int> GetUserId(string user, string password)
    {
        var requestDto = new ValidarLoginPasswordRequest
        {
            lsLogin = user,
            lsPassword = password
        };

        try
        {
            var response = await GetLoginResponse(requestDto);
            return response.Code1 ?? 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private async Task<ValidarLoginPasswordResponse> GetLoginResponse(ValidarLoginPasswordRequest request)
    {
        var response = await SendRequestAsync("ValidarLoginPassword", request.ToSoapBody());
        var xmlNode = GetResponseNodes(response, "ValidarLoginPasswordResult")[0];
        var responseItems = xmlNode.InnerText.Split('|');
        return new ValidarLoginPasswordResponse
        {
            Status = responseItems[0],
            Message = responseItems[1],
            Code1 = responseItems[2] == "" ? null : int.Parse(responseItems[2]),
            Code2 = responseItems[3] == "" ? null : int.Parse(responseItems[3])
        };
    }
}