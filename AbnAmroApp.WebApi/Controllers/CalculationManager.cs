using AbnAmroApp.BusinessLogic;

namespace AbnAmroApp.WebApi.Controllers
{
    public class CalculationManager : ICalculationManager
    {
        private readonly ICalculationService _calculationService;
        private readonly Dictionary<Guid, Task> _taskDictionary = new Dictionary<Guid, Task>();

        public CalculationManager(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public async Task<Guid> StartCalculation(string firstName, string lastName)
        {
            var taskId = Guid.NewGuid();
            var calculationTask = CalculateWithSimulatedDelays(firstName, lastName);

            _taskDictionary.Add(taskId, calculationTask);

            return taskId;
        }

        private async Task<IList<string>> CalculateWithSimulatedDelays(string firstName, string lastName)
        {
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            var result = await _calculationService.Calculate(firstName, lastName);
            return result;
        }

    }
}