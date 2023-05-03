using AbnAmroApp.BusinessLogic.Models;

namespace AbnAmroApp.BusinessLogic.Services
{
    public interface ICalculationManager
    {
        Task<Guid> StartCalculation(string firstName, string lastName);
        Task<StatusObject> GetStatus(Guid taskId);
    }
}