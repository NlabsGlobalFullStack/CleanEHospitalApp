namespace eHospitalServer.Application.Features.Home.GetAllDepartments;

public sealed record DepartmentResponse
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}