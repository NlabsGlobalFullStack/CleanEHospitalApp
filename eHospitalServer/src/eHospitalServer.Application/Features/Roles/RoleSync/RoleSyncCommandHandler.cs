using eHospitalServer.Application.Constants;
using eHospitalServer.Domain.Entities;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Roles.RoleSync;

internal sealed class RoleSyncCommandHandler(
    RoleManager<AppRole> roleManager
) : IRequestHandler<RoleSyncCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RoleSyncCommand request, CancellationToken cancellationToken)
    {
        var currentRoles = await roleManager.Roles.ToListAsync(cancellationToken);
        var staticRoles = RoleConstants.GetRoles();

        foreach (var role in currentRoles)
        {
            if (!staticRoles.Any(p => p.Name == role.Name))
            {
                await roleManager.DeleteAsync(role);
            }
        }

        foreach (var role in staticRoles)
        {
            if (!currentRoles.Any(p => p.Name == role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }

        return Result<string>.Succeed("Sync is successfull");
    }
}
