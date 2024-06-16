using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;

public sealed class VehicleMission : Entity
{
    public string VehicleId { get; set; } = string.Empty;
    public Vehicle? Vehicle { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public Employee? Employee { get; set; }
    public string DoctorId { get; set; } = string.Empty;
    public Doctor? Doctor { get; set; }
    public string NurseId { get; set; } = string.Empty;
    public Nurse? Nurse { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public Patient? Patient { get; set; }
    public string PatientRelative { get; set; } = string.Empty;
    public string TraveledRouteInformation { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public DateTime? MissionDate { get; set; }
}
