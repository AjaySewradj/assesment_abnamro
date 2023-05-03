namespace AbnAmroApp.BusinessLogic.Models
{
    public record StatusObject
    {
        public static StatusObject CreateNotFound() => new StatusObject(Models.Status.NotFound, 0);
        public static StatusObject CreateFailure(int progress) => new StatusObject(Models.Status.Failed, progress);
        public static StatusObject CreateSuccess(int progress, IList<string> result)
        {
            bool isCompleted = progress == 100;
            return isCompleted
                ? new StatusObject(Models.Status.Completed, progress, result) 
                : new StatusObject(Models.Status.Running, progress);
        }

        public string Status { get; init; }

        public int Progress { get; init; }

        public IList<string> Result { get; set; } = new List<string>();

        public StatusObject(string status, int progress, IList<string> result)
        {
            this.Status = status;
            this.Progress = progress;
            this.Result = result;
        }

        public StatusObject(string status, int progress) : this(status, progress, new List<string>())
        {
        }
    }
}