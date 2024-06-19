using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Home.GetAllDoctors;

public sealed record GetAllDoctorsQueryResponse
{
    public string UserImage { get; set; } = default!;
    public string FullName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public SpecialtyEnum Specialty { get; set; } = SpecialtyEnum.Surgeon;
    public decimal AppointmentPrice { get; set; }
}
