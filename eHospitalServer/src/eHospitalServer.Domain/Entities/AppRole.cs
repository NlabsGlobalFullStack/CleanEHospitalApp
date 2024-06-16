using Microsoft.AspNetCore.Identity;

namespace eHospitalServer.Domain.Entities;
public sealed class AppRole : IdentityRole<string>
{
    public AppRole()
    {
        Id = Guid.NewGuid().ToString();
    }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public bool IsUpdated { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
