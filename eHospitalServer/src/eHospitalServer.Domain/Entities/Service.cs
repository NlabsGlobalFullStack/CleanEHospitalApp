using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public sealed class Service : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
}
