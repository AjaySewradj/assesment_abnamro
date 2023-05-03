namespace AbnAmroApp.BusinessLogic
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
            IProgress<int> progressReporter = new Progress<int>(progress =>
            {
                Console.WriteLine("Running Step: {0}", progress);
            });


            var taskId = Guid.NewGuid();
            var calculationTask = CalculateWithSimulatedDelays(firstName, lastName, progressReporter);

            _taskDictionary.Add(taskId, calculationTask);

            return taskId;
        }

        private async Task<IList<string>> CalculateWithSimulatedDelays(string firstName, string lastName, IProgress<int> progressReporter)
        {
            Thread.Sleep(1000);
            progressReporter.Report(20);
            Thread.Sleep(1000);
            progressReporter.Report(40);
            Thread.Sleep(1000);
            progressReporter.Report(60);
            Thread.Sleep(1000);
            progressReporter.Report(80);
            Thread.Sleep(1000);
            var result = await _calculationService.Calculate(firstName, lastName);
            progressReporter.Report(100);

            return result;
        }

    }
}