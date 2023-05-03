namespace AbnAmroApp.WebApi.Controllers
{
    public interface ICalculationManager
    {
        Task<Guid> StartCalculation(string firstName, string lastName);
    }
}