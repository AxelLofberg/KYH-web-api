using System;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Tryck på Enter för att utföra åtgärden.");
            Console.ReadLine();

            Knapp();
        }

        static void Knapp()
        {
            Console.WriteLine("Åtgärnden utförs...");

            Console.WriteLine("Ange ditt namn:");
            string userName = Console.ReadLine();

            Console.WriteLine($"Hej {userName}! Logiken är nu utförd.");
        }
    }
}
