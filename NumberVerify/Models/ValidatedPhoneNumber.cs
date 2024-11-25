using Newtonsoft.Json;

namespace NumberVerify.Models;

internal class ValidatedPhoneNumber
{
    [JsonProperty("valid")]    
    public bool IsNumberValid { get; set; }

    [JsonProperty("local_format")]
    public string? LocalNumber { get; set; }

    [JsonProperty("local_format")]
    public string? CountryPreFix { get; set; }

    [JsonProperty("country_code")]
    public string? CountryCode { get; set; }

}
