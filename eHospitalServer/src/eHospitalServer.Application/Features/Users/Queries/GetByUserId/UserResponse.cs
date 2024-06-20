using eHospitalServer.Domain.Entities;

namespace eHospitalServer.Application.Features.Users.Queries.GetByUserId;

public sealed record UserResponse
{
    public string Id { get; set; } = default!;
    public string IdentityNumber { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public string BloodType { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Town { get; set; } = default!;
    public string FullAddress { get; set; } = default!;
    public int UserType { get; set; } = default!;

    public string Image { get; set; } = default!;

    public Doctor? Doctor { get; set; }
    public Nurse? Nurse { get; set; }
    public Employee? Employee { get; set; }
    public Patient? Patient { get; set; }
}
