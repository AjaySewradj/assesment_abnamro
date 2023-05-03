namespace AbnAmroApp.BusinessLogic
{
    public interface ICalculationService
    {
        Task<IList<string>> Calculate(string firstName, string lastName);
    }
}