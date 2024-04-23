using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Employee : Personal
{
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Emergency;
    public EmployeePositionEnum Position { get; set; } = EmployeePositionEnum.Driver;

    public ICollection<RoomAction>? RoomActions { get; set; }
    public ICollection<VehicleAction>? VehicleActions { get; set; }
    public ICollection<VehicleMission>? VehicleMissions { get; set; }
}
