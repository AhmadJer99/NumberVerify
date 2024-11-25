
namespace NumberVerify.Controllers;

internal class ValidatePhoneNumber
{
    private string? _countryCode;
    private string? _phoneNumber;
    public ValidatePhoneNumber(string countryCode)
    {
        _countryCode = countryCode;
    }

    public void GetPhoneNumber()
    {

    }
}