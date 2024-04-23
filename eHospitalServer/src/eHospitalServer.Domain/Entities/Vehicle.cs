using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Vehicle : Entity
{
    public string Plate { get; set; } = string.Empty;
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Official;
    public byte Capacity { get; set; } = 4;
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    public ICollection<VehicleAction>? VehicleActions { get; set; }
    public ICollection<VehicleMission>? VehicleMissions { get; set; }
}
