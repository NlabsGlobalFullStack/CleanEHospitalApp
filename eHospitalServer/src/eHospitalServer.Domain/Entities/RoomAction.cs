using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;
public class RoomAction : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string RoomId { get; set; } = string.Empty;
    public virtual Room? Room { get; set; }

    public string PatientId { get; set; } = string.Empty;
    public virtual Patient? Patient { get; set; }

    public string NurseId { get; set; } = string.Empty;
    public virtual Nurse? Nurse { get; set; }
}
