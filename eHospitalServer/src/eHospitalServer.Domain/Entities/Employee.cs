using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Employee : Personal
{
    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }
    public PositionEnum Position { get; set; } = PositionEnum.Driver;
}
