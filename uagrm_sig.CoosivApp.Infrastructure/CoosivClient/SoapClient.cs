using System.Globalization;
using System.Text;
using System.Xml;

namespace uagrm_sig.CoosivApp.Infrastructure.CoosivClient;

public class SoapClient(IHttpClientFactory httpClientFactory, string baseUrl, string ns)
{
    protected async Task<string> SendRequestAsync(string action, string bodyContent)
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
        var sb = new StringBuilder();
        sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.Append("<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
        sb.Append("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"");
        sb.Append("xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\">");
        sb.Append("<soap12:Body>");
        sb.Append(bodyContent);
        sb.Append("</soap12:Body>");
        sb.Append("</soap12:Envelope>");
        return sb.ToString();
    }

    protected XmlNodeList GetResponseNodes(string soapResponse, string resultTag)
    {
        var doc = new XmlDocument();
        doc.LoadXml(soapResponse);

        var resultNode = doc.GetElementsByTagName(resultTag);
        return resultNode ?? throw new Exception($"Node '{resultTag}' not found in SOAP response.");
    }

    protected static decimal? ParseNullableDecimal(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

        return null;
    }

    protected static int? ParseNullableInt(string? value)
    {
        return int.TryParse(value, out var result) ? result : null;
    }
}