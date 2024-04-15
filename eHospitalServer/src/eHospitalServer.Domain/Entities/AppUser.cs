using Microsoft.AspNetCore.Identity;

namespace eHospitalServer.Domain.Entities;
public sealed class AppUser : IdentityUser<string>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
}
