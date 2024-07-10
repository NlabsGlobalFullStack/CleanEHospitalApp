using eHospitalServer.Domain.Abstraction;

namespace eHospitalServer.Domain.Entities;

public sealed class VehicleMission : Entity
{
    public string VehicleId { get; set; } = default!;
    public Vehicle? Vehicle { get; set; }
    public string EmployeeId { get; set; } = default!;
    public Employee? Employee { get; set; }
    public string DoctorId { get; set; } = default!;
    public Doctor? Doctor { get; set; }
    public string NurseId { get; set; } = default!;
    public Nurse? Nurse { get; set; }
    public string PatientId { get; set; } = default!;
    public Patient? Patient { get; set; }
    public string PatientRelative { get; set; } = default!;
    public string TraveledRouteInformation { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public string Comments { get; set; } = default!;
    public DateTime? MissionDate { get; set; } = default;
}
