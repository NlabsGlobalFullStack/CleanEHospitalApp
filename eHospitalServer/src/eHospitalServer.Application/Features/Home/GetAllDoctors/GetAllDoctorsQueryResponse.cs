using eHospitalServer.Domain.Enums;

namespace eHospitalServer.Application.Features.Home.GetAllDoctors;

public sealed record GetAllDoctorsQueryResponse
{
    public string UserImage { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string DepartmentName { get; set; } = default!;
    public SpecialtyEnum Specialty { get; set; } = SpecialtyEnum.Surgeon;
    public decimal AppointmentPrice { get; set; }
}
