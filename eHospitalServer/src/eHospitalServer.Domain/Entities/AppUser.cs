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
    public DateTime? EmailConfirmCodeSendDate { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
    public int? ForgotPasswordCode { get; set; }
    public DateTime? ForgotPasswordCodeSendDate { get; set; }

    public Doctor? Doctor { get; set; }
    public Nurse? Nurse { get; set; }
    public Employee? Employee { get; set; }
    public Patient? Patient { get; set; }



    public string CreatedUserId { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string UpdatedUserId { get; set; } = string.Empty;
    public DateTime? UpdatedDate { get; set; }
    public bool IsUpdated { get; set; }
    public string DeletedUserId { get; set; } = string.Empty;
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
