namespace AbnAmroApp.BusinessLogic.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IInMemoryCalculator _inMemoryCalculator;
        private readonly IInDatabaseCalculator _inDatabaseCalculator;

        public CalculationService(IInMemoryCalculator inMemoryCalculator, IInDatabaseCalculator inDatabaseCalculator)
        {
            _inMemoryCalculator = inMemoryCalculator;
            _inDatabaseCalculator = inDatabaseCalculator;
        }

        public async Task<IList<string>> Calculate(string firstName, string lastName)
        {
            // TODO: Make selection configurable
            return await _inMemoryCalculator.Calculate(firstName, lastName);
            //return await _inDatabaseCalculator.Calculate(firstName, lastName);
        }
    }
}