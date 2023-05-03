namespace AbnAmroApp.BusinessLogic.Services
{
    public interface ICalculationManager
    {
        Task<Guid> StartCalculation(string firstName, string lastName);
    }
}