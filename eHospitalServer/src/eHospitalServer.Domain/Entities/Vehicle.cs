using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public sealed class Vehicle : Entity
{
    public string Plate { get; set; } = string.Empty;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Ambulance;
    public int Capacity { get; set; } = 4;
}
