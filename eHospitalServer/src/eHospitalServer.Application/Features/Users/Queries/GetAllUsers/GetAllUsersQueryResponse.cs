namespace eHospitalServer.Application.Features.Users.Queries.GetAllUsers;
public sealed record GetAllUsersQueryResponse
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public List<string> RoleIds { get; set; } = new();
    public List<string?> RoleNames { get; set; } = new();
}
