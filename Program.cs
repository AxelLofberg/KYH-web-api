using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/add", (int num1, int num2) => AddNumbers(num1, num2));

app.MapGet("/subtract", (int num1, int num2) => SubtractNumbers(num1, num2));


app.Run();


string AddNumbers(int num1, int num2)
{
    return $"Summan av {num1} och {num2} = {num1 + num2}";
}

string SubtractNumbers(int num1, int num2)
{
    return $"Diffirensen av {num1} och {num2} = {num1 - num2}";
}


namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
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