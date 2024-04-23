using eHospitalServer.Domain.Abstraction;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Domain.Entities;
public class Doctor : Personal
{
    public DepartmentEnum Department { get; set; } = DepartmentEnum.Emergency;
    public DoctorSpecialtyEnum Specialty { get; set; } = DoctorSpecialtyEnum.Surgeon;
    public decimal AppointmentPrice { get; set; }

    public ICollection<Appointment>? Appointments { get; set; }
    public ICollection<RoomAction>? RoomActions { get; set; }
    public ICollection<VehicleMission>? VehicleMissions { get; set; }
}
