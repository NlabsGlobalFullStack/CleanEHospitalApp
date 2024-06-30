namespace eHospitalServer.Application.Features.Home.GetAllDepartments;

public sealed record DepartmentResponse
{
    public string Name { get; set; } = default!;
    public string Image { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
}