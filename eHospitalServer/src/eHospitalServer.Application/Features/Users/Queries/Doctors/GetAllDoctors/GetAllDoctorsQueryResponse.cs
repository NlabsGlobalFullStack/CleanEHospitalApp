using eHospitalServer.Domain.DTOs;
using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Users.Queries.Doctors.GetAllDoctors;

public sealed record GetAllDoctorsQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public UserDto? User { get; set; }
    public string Department { get; set; } = string.Empty;
    public SpecialtyEnum Specialty { get; set; } = SpecialtyEnum.Surgeon;
    public decimal AppointmentPrice { get; set; }
}
