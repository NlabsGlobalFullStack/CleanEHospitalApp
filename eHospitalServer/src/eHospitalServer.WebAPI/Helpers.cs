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
                    Id = Guid.NewGuid().ToString(),
                    IdentityNumber = "11111111111",
                    FirstName = "Cuma",
                    LastName = "KÖSE",
                    Email = "turkmvc@gmail.com",
                    UserName = "admin",
                    DateOfBirth = new(2000, 1, 1),
                    BloodType = "A rh -",
                    City = "New York",
                    Town = "Brooklyn",
                    EmailConfirmCode = 111111,
                    FullAddress = "Elazıg Kovancılar",
                    EmailConfirmed = true
                }, "String1*");
            }
        }
    }
}
