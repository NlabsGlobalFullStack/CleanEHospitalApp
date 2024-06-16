using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Domain.Repositories.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace eHospitalServer.Persistance.Authentication;
public class JwtProvider(IUserRoleRepository userRoleRepository, RoleManager<AppRole> roleManager, IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    public async Task<LoginCommandResponse> CreateTokenAsync(AppUser user, bool rememberMe)
    {
        var userRoles = await userRoleRepository.Where(r => r.UserId == user.Id).ToListAsync();

        var roles = new List<AppRole>();

        foreach (var userRole in userRoles)
        {
            var role = await roleManager.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefaultAsync();
            if (role is not null)
            {
                roles.Add(role);
            }
        }

        var stringRoles = roles.Select(r => r.Name).ToList();

        var claims = new List<Claim>()
        {
            new Claim("Id", user.Id),
            new Claim("Name", user.FullName),
            new Claim("Email", user.Email ?? string.Empty),
            new Claim("UserName", user.UserName ?? string.Empty),
            new Claim("Role", JsonSerializer.Serialize(stringRoles))
        };

        var expires = rememberMe ? DateTime.Now.AddDays(1) : DateTime.Now.AddHours(1);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signingCredentials
            );

        var handler = new JwtSecurityTokenHandler();

        var token = handler.WriteToken(securityToken);
        var response = new LoginCommandResponse(token);
        return response;
    }
}
