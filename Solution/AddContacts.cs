using System;
using System.IO;
using Spectre.Console;

namespace vCardManager
{
    public class AddContacts
    {
        public static void AddContact()
        {
            var normalize = new NormalizeWords();

            AnsiConsole.MarkupLine("[bold yellow]Enter the contact's name:[/]");
            string name = Console.ReadLine()?.Trim() ?? string.Empty;
            name = normalize.CapitalizeWords(name);

            if (string.IsNullOrWhiteSpace(name))
            {
                AnsiConsole.MarkupLine("[red]Invalid name. It cannot be empty.[/]");
                ReturnToMenu();
                return;
            }

            AnsiConsole.MarkupLine("[bold green]Enter the contact's phone number:[/]");
            string phone = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(phone))
            {
                AnsiConsole.MarkupLine("[red]Invalid phone number. It cannot be empty.[/]");
                ReturnToMenu();
                return;
            }

            AnsiConsole.MarkupLine("[bold aqua]Enter the contact's email address:[/]");
            string email = Console.ReadLine()?.Trim() ?? string.Empty;

            if (!IsValidEmail(email))
            {
                AnsiConsole.MarkupLine("[red]Invalid email. It must contain '@' and '.'[/]");
                ReturnToMenu();
                return;
            }

            Contact newContact = new Contact(name, email, phone);
            string vCard = newContact.ToVcf();
            string filePath = @"../../../contacts.vcf";

            try
            {
                File.AppendAllText(filePath, $"{vCard}\n");
                AnsiConsole.MarkupLine("[green]Success! Contact added![/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]SCRIPT_ERROR: Error adding a contact: {ex.Message}[/]");
            }

            ReturnToMenu();
        }

        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                && email.Contains("@")
                && email.Contains(".");
        }

        public static void ReturnToMenu()
        {
            AnsiConsole.Write(
                new Align(
                    new Panel("[grey]Press any key to return to the menu...[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Grey),
                    HorizontalAlignment.Center));
            Console.ReadKey();
        }
    }
}
