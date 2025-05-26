using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace vCardManager
{
    public static class DisplayContacts
    {
        private class ContactBlock
        {
            public string Name { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
        }

        public static void DisplayAllContacts()
        {
            string filePath = @"../../../contacts.vcf";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                var contacts = new List<ContactBlock>();

                string name = string.Empty;
                string phone = string.Empty;
                string email = string.Empty;

                foreach (string line in lines)
                {
                    if (line.StartsWith("FN:"))
                        name = line.Substring(3);
                    else if (line.StartsWith("TEL:"))
                        phone = line.Substring(4);
                    else if (line.StartsWith("EMAIL:"))
                        email = line.Substring(6);

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(email))
                    {
                        contacts.Add(new ContactBlock
                        {
                            Name = name,
                            Phone = phone,
                            Email = email
                        });

                        name = phone = email = string.Empty;
                    }
                }

                // Tri alphabétique par nom
                var sortedContacts = contacts.OrderBy(c => c.Name).ToList();

                var table = new Table()
                    .Centered()
                    .Border(TableBorder.Rounded)
                    .BorderColor(Color.Grey)
                    .AddColumn("[bold yellow]Name[/]")
                    .AddColumn("[bold green]Phone[/]")
                    .AddColumn("[bold aqua]Email[/]");

                foreach (var contact in sortedContacts)
                {
                    table.AddRow(
                        $"[white]{contact.Name}[/]",
                        $"[white]{contact.Phone}[/]",
                        $"[white]{contact.Email}[/]"
                    );
                }

                AnsiConsole.Write(new Rule("[bold lime]All Contacts (Sorted)[/]").RuleStyle("grey").Centered());
                AnsiConsole.Write(table);

                AnsiConsole.Write(
                    new Align(
                        new Panel("[grey]Press any key to return to the menu...[/]")
                            .Border(BoxBorder.Rounded)
                            .BorderColor(Color.Grey),
                        HorizontalAlignment.Center));
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.Write(
                    new Align(
                        new Panel("[red]SCRIPT_ERROR: The contact file does not exist.[/]")
                            .Border(BoxBorder.Double)
                            .BorderColor(Color.Red),
                        HorizontalAlignment.Center));
                Console.ReadKey();
            }
        }
    }
}
