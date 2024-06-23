namespace eHospitalServer.Application.Features.Departments.GetAllDepartments;

public sealed record DepartmentResponse
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Image { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime CreatedDate { get; set; } = default!;
}