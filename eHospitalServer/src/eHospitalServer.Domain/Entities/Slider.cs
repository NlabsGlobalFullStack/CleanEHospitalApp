using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public sealed class Slider : Entity
{
    public string Title { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Description { get; set; } = default!;
}
