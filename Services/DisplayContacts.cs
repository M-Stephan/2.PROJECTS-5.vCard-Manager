using System.IO;

namespace VCard
{
	public static class DisplayContacts
	{
		public static void DisplayAllContacts()
		{
			string filePath = @"C:\Users\marti\Desktop\5.vCard-Manager\contacts.vcf";

			if (File.Exists(filePath))
			{
				string[] lines = File.ReadAllLines(filePath);

				string name = string.Empty;
				string phone = string.Empty;
				string email = string.Empty;

				foreach (string line in lines)
				{
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

					if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(email))
					{
						Console.WriteLine("-------- Contact --------");
						Console.WriteLine($"Name: {name}");
						Console.WriteLine($"Phone: {phone}");
						Console.WriteLine($"Email: {email}");
						Console.WriteLine("-------------------------");

						// Réinitialiser pour le prochain contact
						name = string.Empty;
						phone = string.Empty;
						email = string.Empty;
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
