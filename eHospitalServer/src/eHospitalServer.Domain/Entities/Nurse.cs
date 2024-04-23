using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Nurse : Personal
{
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Emergency;
    public ShiftEnum Shift { get; set; } = ShiftEnum.Morning;

    public ICollection<VehicleMission>? VehicleMissions { get; set; }
}
