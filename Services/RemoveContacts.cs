using System;
using System.Collections.Generic;
using System.IO;

namespace VCard
{
    public static class RemoveContacts
    {
        public static void RemoveContact(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Please enter a valid contact name.");
                return;
            }

            string filePath = @"C:\Users\marti\Desktop\5.vCard-Manager\contacts.vcf";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("SCRIPT_ERROR: The contact file does not exist.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            List<string> updatedLines = new List<string>();

            bool isContact = false;
            bool skip = false;
            List<string> viewing = new List<string>();
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

                    if (line.StartsWith("FN:") && line.Substring(3).Equals(userInput, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nContact found:");
                        foreach (string l in viewing)
                        Console.WriteLine(l);

                        Console.WriteLine("\nDelete this contact? (y/n)");
                        string confirm = Console.ReadLine()?.ToLower();
                        if (confirm == "y")
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
                Console.WriteLine("SCRIPT_INFO: Success! The contact is removed.");
            }
            else
            {
                Console.WriteLine("SCRIPT_ERROR: Contact not found...");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
