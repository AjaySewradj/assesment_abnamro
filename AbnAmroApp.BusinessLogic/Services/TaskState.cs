using AbnAmroApp.BusinessLogic.Models;

namespace AbnAmroApp.BusinessLogic.Services
{
    public class TaskState
    {
        public Guid Id { get; private set; }

        private readonly StatusObject _state;

        public TaskState()
        {
            Id = Guid.NewGuid();
            _state = new StatusObject(Status.Running, 0);
        }

        public StatusObject GetState() => _state;

        public void UpdateProgress(string status, int progress)
        {
            _state.Status = status;
            _state.Progress = progress;
            Console.WriteLine($"Status = {status}, Progress = {progress}%");
        }

        public void SetResult(IList<string> result)
        {
            _state.Result = result;
        }
    }
}