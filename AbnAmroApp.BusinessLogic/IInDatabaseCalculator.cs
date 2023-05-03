namespace AbnAmroApp.BusinessLogic
{
    public interface IInDatabaseCalculator
    {
        Task<IList<string>> Calculate(string firstName, string lastName);
    }
}