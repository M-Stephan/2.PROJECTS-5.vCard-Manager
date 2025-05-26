namespace vCardManager
{
    public static class ExportContacts
    {
        public static void ExportContactToVcf(string contactName)
        {
            var normalize = new NormalizeWords();
            contactName = normalize.CapitalizeWords(contactName);

            if (string.IsNullOrWhiteSpace(contactName))
            {
                Console.WriteLine("Please enter a valid contact name.");
                return;
            }
            string currentDirectory = Directory.GetCurrentDirectory();


            string filePath = @"../../../contacts.vcf";
            string exportFilePath = Path.Combine(currentDirectory, $@"../../../{contactName}.vcf");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                string name = string.Empty;
                string phone = string.Empty;
                string email = string.Empty;
                bool contactFound = false;

                using (StreamWriter writer = new StreamWriter(exportFilePath))
                {
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("BEGIN:VCARD"))
                        {
                            name = phone = email = string.Empty;
                        }

                        if (line.StartsWith("FN:"))
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

                        if (line.StartsWith("END:VCARD"))
                        {
                            if (name.Equals(contactName, StringComparison.OrdinalIgnoreCase))
                            {
                                writer.WriteLine("BEGIN:VCARD");
                                writer.WriteLine($"FN:{name}");
                                writer.WriteLine($"TEL:{phone}");
                                writer.WriteLine($"EMAIL:{email}");
                                writer.WriteLine("END:VCARD");
                                contactFound = true;
                            }
                        }
                    }
                }

                if (contactFound)
                {
                    Console.WriteLine($"Contact {contactName} exported successfully to {exportFilePath}.");
                }
                else
                {
                    Console.WriteLine("Contact not found to export.");
                }
            }
            else
            {
                Console.WriteLine("SCRIPT_ERROR: The contact file does not exist.");
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
