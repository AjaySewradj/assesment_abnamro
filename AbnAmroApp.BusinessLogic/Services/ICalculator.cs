namespace AbnAmroApp.BusinessLogic.Services
{
    public interface ICalculator
    {
        Task<IList<string>> Calculate(string firstName, string lastName);
    }
}