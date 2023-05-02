using System;
using System.Collections.Generic;
using System.Linq;

namespace AbnAmroApp.ConsoleApp
{
    public class CalculationService
    {
        public IEnumerable<string> Calculate(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));

            var range = Enumerable.Range(1, 100);
            foreach (int number in range)
            {
                if (IsDivisibleBy(number, 3) && IsDivisibleBy(number, 5)) yield return $"{firstName} {lastName}";
                else if (IsDivisibleBy(number, 3)) yield return firstName;
                else if (IsDivisibleBy(number, 5)) yield return lastName;
                else yield return number.ToString();
            }
        }

        public bool IsDivisibleBy(int number, int divisor)
        {
            return number % divisor == 0;
        }
    }
}