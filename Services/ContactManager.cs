using System.IO;

namespace VCard
{
    public static class ContactManager
    {
        public static void SearchContactByName()
        {
            Console.WriteLine("Search contact...");
            Console.ReadKey();
        }

        public static void RemoveContact()
        {
            Console.WriteLine("Remove contact...");
            Console.ReadKey();
        }

        public static void ExportContactToVcf()
        {
            Console.WriteLine("Exporting contact...");
            Console.ReadKey();
        }
    }
}
