namespace AbnAmro.App
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

            var range = Enumerable.Range(1, 100);
            foreach (int number in range)
            {
                if (number % 3 == 0 && number % 5 == 0) Console.WriteLine($"{firstName} {lastName}");
                else if (number % 3 == 0) Console.WriteLine(firstName);
                else if (number % 5 == 0) Console.WriteLine(lastName);
                else Console.WriteLine(number);
            }
        }
    }
}