using NumberVerify.Models;
using NumberVerify.Controllers;
using Spectre.Console;

namespace NumberVerify;

internal class UserInterface
{
    private readonly AppSettings _appSettings = new();
    public void ShowMainMenu()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold teal]Number Verifier\n[/]");
        AnsiConsole.MarkupLine("[red3_1]────────────────────────────────────\n[/]");

        bool shouldExit = false;
        do
        {
            int i = 1;
            AnsiConsole.MarkupLine($"{i++}.[white]Enter A Number[/]");
            AnsiConsole.MarkupLine($"{i}.[white]Change Country Code (Current Country Code = {_appSettings.CurrentCountryCode})[/]\n");

            int userEntry = GetUserEntry(1, i);
            if (userEntry == 0)
                break;
            if (userEntry == -1)
            {
                AnsiConsole.MarkupLine($"[red]Incorrect Option Selected! Please Enter A Valid Option ({1}-{i}) Or 0 To Exit[/]");
                continue;
            }

            ProcessUserEntry(userEntry);
            shouldExit = true;
        }
        while (!shouldExit);
    }

    private int GetUserEntry(int firstOptionNum, int lastOptionNum)
    {
        AnsiConsole.MarkupLine("[red3_1]────────────────────────────────────\n[/]");
        int userEntry = AnsiConsole.Ask<int>($"[bold cyan]Select An Option ({firstOptionNum}-{lastOptionNum}) Or 0 To Exit:[/]");

        if (userEntry == 0)
            return userEntry;
        if (userEntry < firstOptionNum | userEntry > lastOptionNum)
            return -1;
        return userEntry;
    }

    private void ProcessUserEntry(int userEntry)
    {
        if (userEntry == 1)
        {
            ValidatePhoneNumber validatePhoneNumber = new(_appSettings.CurrentCountryCode);
            if (validatePhoneNumber.IsPhoneNumberValid())
                ; // deserialize it here and print out result in a pleasent way.
        }
    }
}