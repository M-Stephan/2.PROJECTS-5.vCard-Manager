using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;

namespace vCardManager
{
    public static class RemoveContacts
    {
        public static void RemoveContact(string userInput)
        {
            var normalize = new NormalizeWords();
            userInput = normalize.CapitalizeWords(userInput);

            if (string.IsNullOrWhiteSpace(userInput))
            {
                AnsiConsole.MarkupLine("[red]Please enter a valid contact name.[/]");
                return;
            }

            string filePath = Path.Combine(AppContext.BaseDirectory, "contacts.vcf");

            if (!File.Exists(filePath))
            {
                AnsiConsole.MarkupLine("[red]SCRIPT_ERROR: The contact file does not exist.[/]");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            List<string> updatedLines = new();
            bool isContact = false;
            bool skip = false;
            List<string> viewing = new();
            bool found = false;

            foreach (string line in lines)
            {
                if (line.StartsWith("BEGIN:VCARD"))
                {
                    isContact = true;
                    viewing.Clear();
                    skip = false;
                }

                if (isContact)
                {
                    viewing.Add(line);

                    if (line.StartsWith("FN:") && line[3..].Equals(userInput, StringComparison.OrdinalIgnoreCase))
                    {
                        AnsiConsole.Write(new Rule($"[yellow]Contact found: {userInput}[/]").Centered());

                        var panel = new Panel(string.Join("\n", viewing))
                            .Border(BoxBorder.Rounded)
                            .BorderColor(Color.Green)
                            .Header("Contact Details", Justify.Center);
                        AnsiConsole.Write(new Align(panel, HorizontalAlignment.Center));

                        var confirm = AnsiConsole.Confirm("[bold red]Delete this contact?[/]");

                        if (confirm)
                        {
                            skip = true;
                            found = true;
                        }
                    }

                    if (line.StartsWith("END:VCARD"))
                    {
                        isContact = false;

                        if (!skip)
                            updatedLines.AddRange(viewing);
                    }

                    continue;
                }

                updatedLines.Add(line);
            }

            if (found)
            {
                File.WriteAllLines(filePath, updatedLines);

                AnsiConsole.Write(new Panel("[green]Success! The contact is removed.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Green)
                    .Expand());
            }
            else
            {
                AnsiConsole.Write(new Panel("[red]SCRIPT_ERROR: Contact not found...[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand());
            }

            AnsiConsole.MarkupLine("\n[grey]Press any key to return to the menu...[/]");
            Console.ReadKey();
        }
    }
}
