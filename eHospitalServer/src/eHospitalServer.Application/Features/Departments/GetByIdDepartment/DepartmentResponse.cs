namespace eHospitalServer.Application.Features.Departments.GetByIdDepartment;

public sealed record DepartmentResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = default!;
}
