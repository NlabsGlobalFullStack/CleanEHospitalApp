using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public sealed class Slider : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
