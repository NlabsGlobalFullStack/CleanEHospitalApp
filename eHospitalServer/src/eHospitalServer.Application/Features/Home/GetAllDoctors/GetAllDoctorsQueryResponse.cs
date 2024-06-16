using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Home.GetAllDoctors;

public sealed record GetAllDoctorsQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public SpecialtyEnum Specialty { get; set; } = SpecialtyEnum.Surgeon;
    public decimal AppointmentPrice { get; set; }
}
