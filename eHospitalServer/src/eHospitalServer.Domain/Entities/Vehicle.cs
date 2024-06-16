using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Vehicle : Entity
{
    public string Plate { get; set; } = string.Empty;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Official;
    public byte Capacity { get; set; } = 4;

    public List<VehicleAction>? VehicleActions { get; set; }
    public List<VehicleMission>? VehicleMissions { get; set; }
}
