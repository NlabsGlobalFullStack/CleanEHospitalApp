using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;

public class VehicleMission : Entity
{
    public string VehicleId { get; set; } = string.Empty;
    public virtual Vehicle? Vehicle { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public virtual Employee? Employee { get; set; }
    public string DoctorId { get; set; } = string.Empty;
    public virtual Doctor? Doctor { get; set; }
    public string NurseId { get; set; } = string.Empty;
    public virtual Nurse? Nurse { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public virtual Patient? Patient { get; set; }
    public string PatientRelative { get; set; } = string.Empty;
    public string TraveledRouteInformation { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public DateTime? MissionDate { get; set; }
}
