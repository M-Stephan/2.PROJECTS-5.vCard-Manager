using Spectre.Console;
using System;
using System.IO;

namespace vCardManager
{
    public static class SearchContacts
    {
        public static void SearchContactByName()
        {
            var normalize = new NormalizeWords();

            var inputName = AnsiConsole.Prompt(
                new TextPrompt<string>("[bold aqua]Enter the name to search:[/]")
                    .PromptStyle("green")
                    .Validate(name => !string.IsNullOrWhiteSpace(name) ? ValidationResult.Success() : ValidationResult.Error("[red]Name cannot be empty![/]"))
            );

            inputName = normalize.CapitalizeWords(inputName);
            string filePath = @"../../../contacts.vcf";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                string name = string.Empty;
                string phone = string.Empty;
                string email = string.Empty;

                bool contactFound = false;

                foreach (string line in lines)
                {
                    if (line.StartsWith("BEGIN:VCARD"))
                    {
                        name = phone = email = string.Empty;
                    }
                    else if (line.StartsWith("FN:"))
                    {
                        name = line.Substring(3);
                    }
                    else if (line.StartsWith("TEL:"))
                    {
                        phone = line.Substring(4);
                    }
                    else if (line.StartsWith("EMAIL:"))
                    {
                        email = line.Substring(6);
                    }
                    else if (line.StartsWith("END:VCARD"))
                    {
                        if (name.Equals(inputName, StringComparison.OrdinalIgnoreCase))
                        {
                            contactFound = true;

                            var table = new Table();
                            table.Border = TableBorder.Rounded;
                            table.AddColumn("[yellow]Field[/]");
                            table.AddColumn("[green]Value[/]");
                            table.AddRow("Name", name);
                            table.AddRow("Phone", phone);
                            table.AddRow("Email", email);

                            AnsiConsole.MarkupLine("[bold underline green]✔ Contact found:[/]");
                            AnsiConsole.Write(table);
                            AnsiConsole.WriteLine();
                        }
                    }
                }

                if (contactFound)
                {
                    var action = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[bold blue]What would you like to do with this contact?[/]")
                            .AddChoices(new[] { "Export", "Delete", "Return to main menu" })
                    );

                    if (action == "Export")
                    {
                        ExportContacts.ExportContactToVcf(inputName);
                    }
                    else if (action == "Delete")
                    {
                        RemoveContacts.RemoveContact(inputName);
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]SCRIPT_ERROR: No contact named [bold]{inputName}[/] was found.[/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[red]SCRIPT_ERROR: Contact file does not exist.[/]");
            }
        }
    }
}
