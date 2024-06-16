using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public sealed class VehicleAction : Entity
{
    public string EmployeeId { get; set; } = string.Empty;
    public Employee? Employee { get; set; }
    public string VehicleId { get; set; } = string.Empty;
    public Vehicle? Vehicle { get; set; }
    public VehicleOperationTypeEnum VehicleOperation { get; set; } = VehicleOperationTypeEnum.Purchased;
    public string Description { get; set; } = string.Empty;
}
