using AbnAmroApp.BusinessLogic.Models;
using System.Security.Cryptography;

namespace AbnAmroApp.BusinessLogic.Services
{
    public class TaskState
    {
        public Guid Id { get; private set; }
        public int Progress { get; set; }
        public IProgress<int> ProgressReporter { get; set; }
        public IList<string> Result { get; set; } = new List<string>();

        public TaskState()
        {
            Id = Guid.NewGuid();
            ProgressReporter = new Progress<int>(UpdateProgress);
        }

        private void UpdateProgress(int progress)
        {
            Progress = progress;
            Console.WriteLine("Running Step: {0}", progress);
        }
    }

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

            return StatusObject.CreateSuccess(taskState.Progress, taskState.Result);
        }

        private async Task CalculateWithSimulatedDelays(string firstName, string lastName, TaskState taskState)
        {
            Thread.Sleep(5000);
            taskState.ProgressReporter.Report(20);
            Thread.Sleep(1000);
            taskState.ProgressReporter.Report(40);
            Thread.Sleep(1000);
            taskState.ProgressReporter.Report(60);
            Thread.Sleep(1000);
            taskState.ProgressReporter.Report(80);
            Thread.Sleep(1000);

            var result = await _calculationService.Calculate(firstName, lastName);
            taskState.ProgressReporter.Report(100);

            taskState.Result = result;
        }

    }
}