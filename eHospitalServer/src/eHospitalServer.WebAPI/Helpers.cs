using eHospitalServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eHospitalServer.WebAPI;
public static class Helpers
{
    public static async Task CreateDefaultUserAsync(WebApplication application)
    {
        using (var scope = application.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(new()
                {
                    FirstName = "Cuma",
                    LastName = "KÖSE",
                    Email = "admin@admin.com",
                    UserName = "admin",
                    EmailConfirmed = true
                }, "String1*");
            }
        }
    }
}
