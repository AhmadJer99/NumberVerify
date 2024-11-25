using System.Configuration;
using NumberVerify.Controllers.ApiInterfaces;

namespace NumberVerify.Controllers;

public class HttpRequestCreator : IValidateNumber
{
    public HttpClient CreateHttpClient()
    {
        return new HttpClient();
    }

    public string LoadApiKey()
    {
        return ConfigurationManager.AppSettings.Get("numVerifyApiKey") ?? "";
    }

    public string LoadHttpValidationConnectionString()
    {
        return ConfigurationManager.AppSettings.Get("ValidationHttpEndpoint") ?? "";
    }
}