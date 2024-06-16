namespace eHospitalServer.Domain.DTOs;
public sealed record FaqDto
{
    public string Id { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public DateOnly PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
}
