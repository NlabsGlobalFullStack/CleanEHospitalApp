using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public sealed class Faq : Entity
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public DateOnly PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
}
