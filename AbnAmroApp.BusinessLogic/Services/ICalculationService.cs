namespace AbnAmroApp.BusinessLogic.Services
{
    public interface ICalculationService
    {
        Task<IList<string>> Calculate(string firstName, string lastName);
    }
}