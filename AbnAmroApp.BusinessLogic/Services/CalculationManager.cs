using AbnAmroApp.BusinessLogic.Models;
using System.Security.Cryptography;

namespace AbnAmroApp.BusinessLogic.Services
{
    public class CalculationManager : ICalculationManager
    {
        private readonly ICalculationService _calculationService;
        private readonly Dictionary<Guid, TaskState> _taskDictionary = new Dictionary<Guid, TaskState>();

        public CalculationManager(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public async Task<Guid> StartCalculation(string firstName, string lastName)
        {
            var taskState = new TaskState();

            var calculationTask = Task.Run(() => CalculateWithSimulatedDelays(firstName, lastName, taskState));

            _taskDictionary.Add(taskState.Id, taskState);

            return taskState.Id;
        }

        public async Task<StatusObject> GetStatus(Guid taskId)
        {
            if (!_taskDictionary.TryGetValue(taskId, out var taskState))
            {
                return StatusObject.CreateNotFound();
            }

            return taskState.GetState();
        }

        private async Task CalculateWithSimulatedDelays(string firstName, string lastName, TaskState taskState)
        {
            const int minDelay = 20;
            const int maxDelay = 60;
            const int randomFailFactor = 9;

            Random random = new Random(Guid.NewGuid().GetHashCode());
            var delayInSeconds = random.Next(minDelay, maxDelay);

            if (delayInSeconds % randomFailFactor == 0)
            {
                taskState.UpdateProgress(Status.Failed, delayInSeconds);
                return;
            }

            for (int i = 0; i < delayInSeconds; i++)
            {
                Thread.Sleep(1000);
                int progress = Convert.ToInt32((i / (double)maxDelay) * 100);
                taskState.UpdateProgress(Status.Running, progress);
            }

            var result = await _calculationService.Calculate(firstName, lastName);
            taskState.UpdateProgress(Status.Completed, 100);
            taskState.SetResult(result);
        }

    }
}