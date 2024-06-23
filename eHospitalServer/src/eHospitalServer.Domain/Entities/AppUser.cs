using Microsoft.AspNetCore.Identity;

namespace eHospitalServer.Domain.Entities;
public class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string? Image { get; set; }
    public string IdentityNumber { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateOnly DateOfBirth { get; set; }
    public string BloodType { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Town { get; set; } = default!;
    public string FullAddress { get; set; } = default!;
    public int EmailConfirmCode { get; set; } = default!;
    public DateTime? EmailConfirmCodeSendDate { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
    public int? ForgotPasswordCode { get; set; }
    public DateTime? ForgotPasswordCodeSendDate { get; set; }

    public Doctor? Doctor { get; set; }
    public Nurse? Nurse { get; set; }
    public Employee? Employee { get; set; }
    public Patient? Patient { get; set; }

    public string? CreatedUser { get; set; } = default;
    public DateTime CreatedDate { get; set; } = default!;
    public string? UpdatedUser { get; set; } = default;
    public DateTime? UpdatedDate { get; set; }
    public bool IsUpdated { get; set; }
    public string? DeletedUser { get; set; } = default;
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
