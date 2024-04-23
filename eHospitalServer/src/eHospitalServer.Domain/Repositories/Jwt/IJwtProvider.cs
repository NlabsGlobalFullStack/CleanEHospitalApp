using eHospitalServer.Domain.Entities;

namespace eHospitalServer.Domain.Repositories.Jwt;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(AppUser user, bool rememberMe);
}
