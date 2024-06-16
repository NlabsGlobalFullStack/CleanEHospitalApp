namespace eHospitalServer.Application.Features.Users.Queries.Users.GetAllUsers;

public sealed record GetAllUsersQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string BloodType { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    public string FullAddress { get; set; } = string.Empty;
    public List<string> RoleIds { get; set; } = new();
    public List<string?> RoleNames { get; set; } = new();
}