using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public sealed class Nurse : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Emergency;
    public ShiftEnum Shift { get; set; } = ShiftEnum.Morning;
    public bool IsActive { get; set; } = true;
}
