namespace AbnAmroApp.BusinessLogic.Services
{
    public interface IInDatabaseCalculator
    {
        Task<IList<string>> Calculate(string firstName, string lastName);
    }
}