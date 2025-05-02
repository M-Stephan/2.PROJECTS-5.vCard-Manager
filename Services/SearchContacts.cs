using System;
using System.IO;

namespace VCard
{
    public static class SearchContacts
    {
        public static void SearchContactByName()
        {
            Console.WriteLine("Enter the name to search:");
            string inputName = Console.ReadLine();
            string filePath = @"C:\Users\marti\Desktop\5.vCard-Manager\contacts.vcf";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                string name = string.Empty;
                string phone = string.Empty;
                string email = string.Empty;

                foreach (string line in lines)
                {
                    if (line.StartsWith("BEGIN:VCARD"))
                    {
                        // Reset les infos du contact à chaque nouveau bloc
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
                        // Une fois le bloc terminé, on vérifie si le nom correspond
                        if (name.Equals(inputName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("-------- Contact --------");
                            Console.WriteLine($"Name: {name}");
                            Console.WriteLine($"Phone: {phone}");
                            Console.WriteLine($"Email: {email}");
                            Console.WriteLine("-------------------------\n");
                        }
                    }
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("SCRIPT_ERROR: The contact file does not exist.");
            }
        }
    }
}
