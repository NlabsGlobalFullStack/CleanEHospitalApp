using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Users.Queries.Users.GetAllUsers;

internal sealed class GetAllUsersQueryHandler(
    UserManager<AppUser> userManager,
    RoleManager<AppRole> roleManager,
    IUserRoleRepository userRoleRepository
) : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUsersQueryResponse>>>
{
    public async Task<Result<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken);

        List<GetAllUsersQueryResponse> response =
            users.Select(s => new GetAllUsersQueryResponse()
            {
                Id = s.Id,
                IdentityNumber = s.IdentityNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
                FullName = s.FullName,
                UserName = s.UserName,
                Email = s.Email,
                DateOfBirth = s.DateOfBirth,
                BloodType = s.BloodType,
                City = s.City,
                Town = s.Town,
                FullAddress = s.FullAddress
            }).ToList();

        foreach (var item in response)
        {
            List<AppUserRole> userRoles = await userRoleRepository.Where(p => p.UserId == item.Id).ToListAsync(cancellationToken);

            List<string> stringRoles = new();
            List<string?> stringRoleNames = new();

            foreach (var userRole in userRoles)
            {
                AppRole? role =
                    await roleManager
                    .Roles
                    .Where(p => p.Id == userRole.RoleId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (role is not null)
                {
                    stringRoles.Add(role.Id);
                    stringRoleNames.Add(role.Name);
                }
            }

            item.RoleIds = stringRoles;
            item.RoleNames = stringRoleNames;
        }

        return response;
    }
}
