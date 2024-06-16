namespace eHospitalServer.Domain.Entities;
public class Appointment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string DoctorId { get; set; } = string.Empty;
    public Doctor? Doctor { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public Patient? Patient { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
