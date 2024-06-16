using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
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
                    IdentityNumber = "11111111111",
                    FirstName = "Cuma",
                    LastName = "KÖSE",
                    Email = "admin@admin.com",
                    UserName = "admin",
                    DateOfBirth = new(2000, 1, 1),
                    BloodType = "A rh -",
                    City = "New York",
                    Town = "Brooklyn",
                    EmailConfirmCode = 111111,
                    EmailConfirmed = true
                }, "String1*");
            }
            var settingRepository = scope.ServiceProvider.GetRequiredService<ISettingRepository>();
            var setting = settingRepository.GetAll().ToList();
            if (setting.Count <= 0)
            {
                var newSetting = new Setting()
                {
                    LogoUrl = "logo.png",
                    Title = "Clean Hospital App",
                    Author = "Cuma KÖSE",
                    PhoneNumber = "+90 541 962 51 34",
                    Email = "turkmvc@gmail.com",
                    Address = "Elazığ",
                    Facebook = "turkmvc",
                    Instagram = "turkmvc",
                    Twitter = "turkmvc",
                    Linkedin = "turkmvc",
                    Youtube = "turkmvc",
                    Descriptions = "Descriptions",
                    Keywords = "Keywords",
                    About = "About",
                    MapsCode = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3009.208239912099!2d29.00630807574685!3d41.04257501731289!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab1115a3c0d87%3A0x96bde3e1e896cda2!2s%C4%B0stanbul%20E%C4%9Fitim%20Akademi!5e0!3m2!1str!2str!4v1714239014344!5m2!1str!2str\\\" width=\\\"600\\\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>"
                };
                settingRepository.Add(newSetting);
            }
        }
    }
}
