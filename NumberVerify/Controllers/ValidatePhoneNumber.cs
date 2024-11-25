using NumberVerify.Models;

namespace NumberVerify.Controllers;

internal class ValidatePhoneNumber
{
    private string? _countryCode;
    private string? _phoneNumber;
    private ValidatedPhoneNumber? _numberDetails;
    public ValidatePhoneNumber(string countryCode)
    {
        _countryCode = "&country_code=" + countryCode;
        _phoneNumber = "&number=" + EnterValidNumber.GetPhoneNumber();
    }

    public bool IsPhoneNumberValid()
    {
        var task = LoadPhoneDetails();
        task.Wait();

        return _numberDetails.IsNumberValid;
    }
    private async Task LoadPhoneDetails()
    {
        HttpRequestCreator httpRequestCreator = new();
        var client = httpRequestCreator.CreateHttpClient();
        var apiKey = httpRequestCreator.LoadApiKey();
        var requestUri = httpRequestCreator.LoadHttpValidationConnectionString();
        var fullUri = requestUri + apiKey + _phoneNumber + _countryCode;

        _numberDetails = await ApiRequest.ProcessRequestAsync<ValidatedPhoneNumber>(client, fullUri);
    }
}