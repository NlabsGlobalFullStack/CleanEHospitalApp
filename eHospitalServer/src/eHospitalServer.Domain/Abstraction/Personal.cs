using eHospitalServer.Domain.Entities;

namespace eHospitalServer.Domain.Abstraction;
public abstract class Personal
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    public AppUser? User { get; set; }
    public List<Appointment>? Appointments { get; set; }
    public List<RoomAction>? RoomActions { get; set; }
    public List<VehicleAction>? VehicleActions { get; set; }
    public List<VehicleMission>? VehicleMissions { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public bool IsUpdated { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
