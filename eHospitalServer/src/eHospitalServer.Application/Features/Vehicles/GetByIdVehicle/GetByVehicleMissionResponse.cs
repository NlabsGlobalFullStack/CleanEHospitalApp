using eHospitalServer.Domain.Entities;

namespace eHospitalServer.Application.Features.Vehicles.GetByIdVehicle;

public sealed record GetByVehicleMissionResponse
{
    public string Id { get; set; } = default!;
    public string VehicleId { get; set; } = default!;
    public Vehicle? Vehicle { get; set; }
    public string VehiclePlate { get; set; } = default!;
    public string EmployeeId { get; set; } = default!;
    public Employee? Employee { get; set; }
    public string EmployeeName { get; set; } = default!;
    public string DoctorId { get; set; } = default!;
    public Doctor? Doctor { get; set; }
    public string DoctorName { get; set; } = default!;
    public string NurseId { get; set; } = default!;
    public Nurse? Nurse { get; set; }
    public string NurseName { get; set; } = default!;
    public string PatientId { get; set; } = default!;
    public Patient? Patient { get; set; }
    public string PatientName { get; set; } = default!;
    public string PatientRelative { get; set; } = default!;
    public string TraveledRouteInformation { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public string Comments { get; set; } = default!;
    public DateTime? MissionDate { get; set; } = default;

    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = default;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; } = default;
    public bool IsUpdated { get; set; }
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; }
}
