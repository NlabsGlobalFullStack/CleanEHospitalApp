using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public class Patient : Personal
{
    public ICollection<Appointment>? Appointments { get; set; }
    public ICollection<RoomAction>? RoomActions { get; set; }
    public ICollection<VehicleMission>? VehicleMissions { get; set; }
}
