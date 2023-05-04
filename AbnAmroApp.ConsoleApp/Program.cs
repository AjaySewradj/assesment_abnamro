using System;
using System.Threading.Tasks;
using AbnAmroApp.BusinessLogic.Services;

namespace AbnAmroApp.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome!");

            string firstName = GetUserInput("\nPlease enter your first name:");
            string lastName = GetUserInput("\nPlease enter your last name:");

            Console.WriteLine($"\nThanks. You've entered '{firstName} {lastName}'");

            // TODO: Add configuration
            // TODO: Add dependency injection

            // TODO: make the selection configurable
            //var calculator = new InMemoryCalculator();
            var calculator = new InDatabaseCalculator();

            var calculationService = new CalculationService(calculator);
            var results = await calculationService.Calculate(firstName, lastName);

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