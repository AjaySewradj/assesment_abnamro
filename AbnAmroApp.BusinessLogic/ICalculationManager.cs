namespace AbnAmroApp.BusinessLogic
{
    public interface ICalculationManager
    {
        Task<Guid> StartCalculation(string firstName, string lastName);
    }
}