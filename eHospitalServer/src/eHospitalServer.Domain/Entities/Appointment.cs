namespace eHospitalServer.Domain.Entities;
public sealed class Appointment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string DoctorId { get; set; } = default!;
    public Doctor? Doctor { get; set; }
    public string PatientId { get; set; } = default!;
    public Patient? Patient { get; set; }
    public DateTime StartDate { get; set; } = default!;
    public DateTime EndDate { get; set; } = default!;
    public bool IsCompleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; } = default;
    public bool IsDeleted { get; set; } = false;
}
