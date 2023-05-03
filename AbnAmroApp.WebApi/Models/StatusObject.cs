namespace AbnAmroApp.WebApi.Models
{
    public record StatusObject(Status Status, int Progress, IList<string> Result);
}