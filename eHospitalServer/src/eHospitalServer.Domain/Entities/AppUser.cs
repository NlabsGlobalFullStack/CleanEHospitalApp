using eHospitalServer.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace eHospitalServer.Domain.Entities;
public class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string IdentityNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateOnly DateOfBirth { get; set; }
    public string BloodType { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    public string FullAddress { get; set; } = string.Empty;
    public int EmailConfirmCode { get; set; }
    public DateTime EmailConfirmCodeSendDate { get; set; } = DateTime.Now;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
    public int? ForgotPasswordCode { get; set; }
    public DateTime? ForgotPasswordCodeSendDate { get; set; }
    public UserTypeEnum UserType { get; set; } = UserTypeEnum.Patient;
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}
