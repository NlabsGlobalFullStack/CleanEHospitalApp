using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Doctor : Personal
{
    public string DepartmentId { get; set; } = string.Empty;
    public Department? Department { get; set; }
    public SpecialtyEnum Specialty { get; set; } = SpecialtyEnum.Surgeon;
    public decimal AppointmentPrice { get; set; }
}
