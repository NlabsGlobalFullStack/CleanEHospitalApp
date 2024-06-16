using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Nurse : Personal
{
    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }
    public ShiftEnum Shift { get; set; } = ShiftEnum.Morning;
}
