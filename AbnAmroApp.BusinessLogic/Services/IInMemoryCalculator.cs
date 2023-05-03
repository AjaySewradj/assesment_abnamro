namespace AbnAmroApp.BusinessLogic.Services
{
    public interface IInMemoryCalculator
    {
        Task<IList<string>> Calculate(string firstName, string lastName);
        bool IsDivisibleBy(int number, int divisor);
    }
}