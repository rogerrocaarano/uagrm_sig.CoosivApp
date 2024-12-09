using System.Globalization;
using System.Text;
using System.Xml;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient;

public class SoapClient(IHttpClientFactory httpClientFactory, string baseUrl, string ns)
{
    public async Task<string> SendRequestAsync(string action, string bodyContent)
    {
        var soapRequest = BuildSoapEnvelope(bodyContent);
        var content = new StringContent(soapRequest, Encoding.UTF8, "application/soap+xml");

        content.Headers.Add("SOAPAction", $"{ns}/{action}");

        var client = httpClientFactory.CreateClient();
        var response = await client.PostAsync(baseUrl, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"SOAP request failed. Status: {response.StatusCode}, Message: {await response.Content.ReadAsStringAsync()}");
        }

        return await response.Content.ReadAsStringAsync();
    }

    private string BuildSoapEnvelope(string bodyContent)
    {
        return $@"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                          xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                          xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
            <soap12:Body>
                {bodyContent}
            </soap12:Body>
        </soap12:Envelope>";
    }

    public XmlNodeList GetResponseNodes(string soapResponse, string resultTag)
    {
        var doc = new XmlDocument();
        doc.LoadXml(soapResponse);

        var resultNode = doc.GetElementsByTagName(resultTag);
        return resultNode ?? throw new Exception($"Node '{resultTag}' not found in SOAP response.");
    }
}