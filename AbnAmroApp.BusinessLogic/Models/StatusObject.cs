namespace AbnAmroApp.BusinessLogic.Models
{
    public record StatusObject
    {
        public static StatusObject CreateNotFound() => new StatusObject(Models.Status.NotFound, 0);

        public string Status { get; set; }

        public int Progress { get; set; }

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