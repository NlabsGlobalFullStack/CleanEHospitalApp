using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class VehicleAction : Entity
{
    public string EmployeeId { get; set; } = string.Empty;
    public virtual Employee? Employee { get; set; }
    public string VehicleId { get; set; } = string.Empty;
    public virtual Vehicle? Vehicle { get; set; }
    public VehicleOperationTypeEnum VehicleOperation { get; set; } = VehicleOperationTypeEnum.Purchased;
    public string Description { get; set; } = string.Empty;
}
