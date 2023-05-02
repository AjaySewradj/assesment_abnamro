namespace AbnAmroApp.BusinessLogic
{
    public class CalculationService
    {
        private readonly InMemoryCalculator _inMemoryCalculator;
        private readonly InDatabaseCalculator _inDatabaseCalculator;

        public CalculationService(InMemoryCalculator inMemoryCalculator, InDatabaseCalculator inDatabaseCalculator)
        {
            _inMemoryCalculator = inMemoryCalculator;
            _inDatabaseCalculator = inDatabaseCalculator;
        }

        public IList<string> Calculate(string firstName, string lastName)
        {
            // TODO: Make selection configurable
            //return _inMemoryCalculator.Calculate(firstName, lastName);
            return _inDatabaseCalculator.Calculate(firstName, lastName);
        }


        private IList<string> CalculateInMemory(string firstName, string lastName) => _inMemoryCalculator.Calculate(firstName, lastName);
        private IList<string> CalculateInDatabase(string firstName, string lastName) => _inDatabaseCalculator.Calculate(firstName, lastName);
    }
}