using System;
using AbnAmroApp.BusinessLogic;

namespace AbnAmroApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");

            string firstName = GetUserInput("\nPlease enter your first name:");
            string lastName = GetUserInput("\nPlease enter your last name:");

            Console.WriteLine($"\nThanks. You've entered '{firstName} {lastName}'");

            var calculationService = new CalculationService(new InMemoryCalculator(), new InDatabaseCalculator());
            var results = calculationService.Calculate(firstName, lastName);

            foreach (string line in results)
            {
                Console.WriteLine(line);
            }
        }

        private static string GetUserInput(string prompt)
        {
            string input = "";
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            }

            return input;
        }
    }
}