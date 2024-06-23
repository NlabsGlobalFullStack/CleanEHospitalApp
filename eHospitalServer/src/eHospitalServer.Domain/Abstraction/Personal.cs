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
    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsUpdated { get; set; } = false;
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; } = false;
}
