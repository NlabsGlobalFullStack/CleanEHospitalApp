using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public sealed class Employee : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public EmployeePositionEnum Position { get; set; } = EmployeePositionEnum.Janitor;
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Emergency;
    public bool IsActive { get; set; } = true;
}
