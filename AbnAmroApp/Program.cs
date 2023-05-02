using System;

namespace AbnAmroApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("\nPlease enter your first name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("\nPlease enter your last name:");
            var lastName = Console.ReadLine();

            Console.WriteLine($"\nThanks. You've entered '{firstName} {lastName}'");

            var calculationService = new CalculationService();
            var results = calculationService.Calculate(firstName, lastName);

            foreach (string line in results)
            {
                Console.WriteLine(line);
            }
        }
    }
}