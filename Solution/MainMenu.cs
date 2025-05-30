using Spectre.Console;

namespace vCardManager
{
    public class MainMenu
    {
        public void DisplayMenu()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();

                AnsiConsole.Write(
                    new FigletText("vCard Manager")
                        .Centered()
                        .Color(Color.Red));

                AnsiConsole.Write(new Rule("[yellow]Main Menu[/]"));

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold aqua]What would you like to do?[/]")
                        .AddChoices(new[]
                        {
                            "Display all contacts",
                            "Add a new contact",
                            "Search contact by name",
                            "Exit"
                        }));

                switch (choice)
                {
                    case "Display all contacts":
                        DisplayContacts.DisplayAllContacts();
                        AnsiConsole.MarkupLine("\n[grey]Press any key to return to the menu...[/]");
                        Console.ReadKey();
                        break;

                    case "Add a new contact":
                        AddContacts.AddContact();
                        AnsiConsole.MarkupLine("\n[grey]Press any key to return to the menu...[/]");
                        Console.ReadKey();
                        break;

                    case "Search contact by name":
                        SearchContacts.SearchContactByName();
                        AnsiConsole.MarkupLine("\n[grey]Press any key to return to the menu...[/]");
                        Console.ReadKey();
                        break;

                    case "Exit":
                        run = false;
                        AnsiConsole.MarkupLine("[red]Goodbye![/]");
                        Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
