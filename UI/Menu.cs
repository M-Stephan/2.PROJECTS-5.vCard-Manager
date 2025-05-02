using VCard;

public class Menu
{
    public static void DisplayMenu()
    {
        bool run = true;

        while (run)
        {
            Console.Clear();
            Console.WriteLine("•○O vCard Manager O○•");
            Console.WriteLine("↓↓↓ Choose an option: ↓↓↓");
            Console.WriteLine("[1]: Display all contacts");
            Console.WriteLine("[2]: Add a new contact");
            Console.WriteLine("[3]: Search contact by name");
            Console.WriteLine("[4]: Exit");

            string strChoice = Console.ReadLine();
            try
            {
                int choice = int.Parse(strChoice);
                switch (choice)
                {
                    case 1:
                        DisplayContacts.DisplayAllContacts();
                        break;
                    case 2:
                        AddContacts.AddContact();
                        break;
                    case 3:
                        SearchContacts.SearchContactByName();
                        break;
                    case 4:
                        run = false;
                        break;
                    default:
                        throw new ArgumentException("Please enter a number between 1 to 4");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(" Invalid input. Please enter a number between 1 and 4.");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        }
    }
}