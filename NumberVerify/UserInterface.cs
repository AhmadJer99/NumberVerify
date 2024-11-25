using NumberVerify.Models;
using NumberVerify.Controllers;
using Spectre.Console;

namespace NumberVerify;

internal class UserInterface
{
    private readonly AppSettings _appSettings = new();
    public void ShowMainMenu()
    {
        bool shouldExit = false;
        do
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold teal]Number Verifier\n[/]");
            AnsiConsole.MarkupLine("[red3_1]────────────────────────────────────\n[/]");

            int i = 1;
            AnsiConsole.MarkupLine($"{i++}.[white]Enter A Number[/]");
            AnsiConsole.MarkupLine($"{i}.[white]Change Country Prefix (Current Country Code = {_appSettings.CurrentCountryCode})[/]\n");

            int userEntry = GetUserEntry(1, i);
            if (userEntry == 0)
                break;
            if (userEntry == -1)
            {
                AnsiConsole.MarkupLine($"[red]Incorrect Option Selected! Please Enter A Valid Option ({1}-{i}) Or 0 To Exit[/]");
                continue;
            }
            ProcessUserEntry(userEntry);
            AnsiConsole.MarkupLine($"[white]Press Any Key To Continue[/]");
            Console.ReadKey();
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
            ShowStatusLogo();
            if (validatePhoneNumber.IsPhoneNumberValid())
            {
                AnsiConsole.Ask<int>("[bold green]This number seems correct![/]");
                return;
            }
            AnsiConsole.Ask<int>("[bold red]This number is not correct!\n(Either the number is incorrect or the country code is incorrect.)[/]");
            return;
        }
        if (userEntry == 2)
        {
            AnsiConsole.MarkupLine("\n[red3_1]────────────────────────────────────\n[/]");
            bool validCode = false;
            do
            {
                var countryCode = AnsiConsole.Ask<string>("[teal bold]Please enter your country code in this specified format e.g (Jordan -> JO):[/]");
                if (countryCode.Length != 2)
                {
                    AnsiConsole.Ask<int>("[bold red]This code incorrect![/]");
                        continue;
                }
                _appSettings.CurrentCountryCode = countryCode;
                return;
            } while (!validCode);
        }
    }

    private void ShowStatusLogo()
    {
        AnsiConsole.Status()
                   .Start("Processing...", ctx =>
                   {
                       // Simulate some work
                       AnsiConsole.MarkupLine("Processing Phone Number...");
                       Thread.Sleep(1000);

                       // Update the status and spinner
                       ctx.Status("Processing");
                       ctx.Spinner(Spinner.Known.Star);
                       ctx.SpinnerStyle(Style.Parse("green"));
                   });
    }
}