using System;
using System.IO;

namespace VCard
{
    public class AddContacts
    {
        public static void AddContact()
        {
            Console.WriteLine("Enter the contact's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the contact's phone number:");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter the contact's email address:");
            string email = Console.ReadLine();

            Contact newContact = new Contact(name, email, phone);

            string vCard = newContact.ToVcf();

            string filePath = @"C:\Users\marti\Desktop\5.vCard-Manager\contacts.vcf";

            try
            {
                File.AppendAllText(filePath, $"{vCard}\n");
                Console.WriteLine("SCRIPT_INFO: Success! Contact added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SCRIPT_ERROR: Error adding a contact: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}