using Spectre.Console;
namespace NumberVerify.Controllers;

internal static class EnterValidNumber
{
    public static string GetPhoneNumber()
    {
        bool validNumber = false;
        AnsiConsole.MarkupLine("\n[red3_1]────────────────────────────────────\n[/]");
        do
        {
            var phoneNumber = AnsiConsole.Ask<string>("\n[teal]Please enter a valid phone number ((Dont Include The Country Prefix) e.g 787964386)[/]:");
            // ansi console already handles null or empty
            if (!double.TryParse(phoneNumber, out double _))
            {
                AnsiConsole.MarkupLine("[red]Invalid Phone Number-No characters allowed in the phone number![/]");
                continue;
            }
            if (phoneNumber.Length < 3 | phoneNumber.Length > 17) // the only allowed range for any phone number
            {
                AnsiConsole.MarkupLine("[red]Invalid Phone Number-The entered number exceeds the allowed length![/]");
                continue;
            }
            AnsiConsole.MarkupLine($"[green]Valid Phone Number! : {phoneNumber}[/]");
            return phoneNumber;
        } while (!validNumber);
        return "";
    }
}
