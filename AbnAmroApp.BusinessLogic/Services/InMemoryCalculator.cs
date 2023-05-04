namespace AbnAmroApp.BusinessLogic.Services
{
    public class InMemoryCalculator : ICalculator
    {
        public async Task<IList<string>> Calculate(string firstName, string lastName)
        {
            var result = CalculateInner(firstName, lastName).ToList();
            return await Task.FromResult(result);
        }

        private IEnumerable<string> CalculateInner(string firstName, string lastName)
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
            if (divisor <= 0) return false;
            return number % divisor == 0;
        }
    }
}