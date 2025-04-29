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
            Console.WriteLine("[4]: Remove a contact");
            Console.WriteLine("[5]: Export contact to .vcf file");
            Console.WriteLine("[6]: Exit");

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
                        ContactManager.SearchContactByName();
                        break;
                    case 4:
                        ContactManager.RemoveContact();
                        break;
                    case 5:
                        ContactManager.ExportContactToVcf();
                        break;
                    case 6:
                        run = false;
                        break;
                    default:
                        throw new ArgumentException("Please enter a number between 1 to 6");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        }
    }
}