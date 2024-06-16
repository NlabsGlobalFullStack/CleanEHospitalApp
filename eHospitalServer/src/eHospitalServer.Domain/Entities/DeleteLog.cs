namespace eHospitalServer.Domain.Entities;
public sealed class DeleteLog
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;
    public string Object { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; } = DateTime.Now;
}
