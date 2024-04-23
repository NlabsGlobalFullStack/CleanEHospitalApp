using eHospitalServer.Domain.Entities;

namespace eHospitalServer.Application.Constants;
public static class RoleConstants
{
    public static IList<AppRole> GetRoles()
    {
        var roles = new List<string>()
        {
            "Admin",
            "Doctor",
            "Nurse",
            "Patient"
        };

        return roles.Select(s => new AppRole() { Name = s }).ToList();
    }
}
