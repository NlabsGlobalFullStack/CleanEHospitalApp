using eHospitalServer.Domain.Entities;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Users.Queries.GetAllUsers;

internal sealed class GetAllUsersQueryHandler(
    UserManager<AppUser> userManager,
    RoleManager<AppRole> roleManager,
    IUserRoleRepository userRoleRepository
) : IRequestHandler<GetAllUsersQuery, Result<IList<GetAllUsersQueryResponse>>>
{
    public async Task<Result<IList<GetAllUsersQueryResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);

        IList<GetAllUsersQueryResponse> response = users.Select(s => new GetAllUsersQueryResponse()
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            FullName = s.FullName,
            UserName = s.UserName,
            Email = s.Email
        }).ToList();

        foreach (var item in response)
        {
            var userRoles = await userRoleRepository.Where(p => p.UserId == item.Id).ToListAsync(cancellationToken);

            var stringRoles = new List<string>();
            var stringRoleNames = new List<string?>();

            foreach (var userRole in userRoles)
            {
                var role = await roleManager.Roles.Where(p => p.Id == userRole.RoleId).FirstOrDefaultAsync(cancellationToken);
                if (role is not null)
                {
                    stringRoles.Add(role.Id);
                    stringRoleNames.Add(role.Name);
                }
            }

            item.RoleIds = stringRoles;
            item.RoleNames = stringRoleNames;
        }

        return response.ToList();
    }
}
