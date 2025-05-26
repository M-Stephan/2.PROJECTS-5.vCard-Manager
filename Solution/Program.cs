using System;
using Spectre.Console;
using vCardManager;

namespace vCardManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainMenu mainMenu = new();
            mainMenu.DisplayMenu();
        }
    }
}