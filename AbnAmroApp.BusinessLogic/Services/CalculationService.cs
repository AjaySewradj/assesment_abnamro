namespace AbnAmroApp.BusinessLogic.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculator _calculator;

        public CalculationService(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public async Task<IList<string>> Calculate(string firstName, string lastName)
        {
            return await _calculator.Calculate(firstName, lastName);
        }
    }
}