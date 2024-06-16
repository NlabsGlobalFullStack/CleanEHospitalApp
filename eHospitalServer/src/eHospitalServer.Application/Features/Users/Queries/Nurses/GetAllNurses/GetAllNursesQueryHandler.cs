using eHospitalServer.Domain.DTOs;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Users.Queries.Nurses.GetAllNurses;

internal sealed class GetAllNursesQueryHandler(
    INurseRepository nurseRepository
) : IRequestHandler<GetAllNursesQuery, Result<List<GetAllNursesQueryResponse>>>
{
    public async Task<Result<List<GetAllNursesQueryResponse>>> Handle(GetAllNursesQuery request, CancellationToken cancellationToken)
    {
        var doctors = await nurseRepository.GetAll()
                .Include(p => p.Department)
                .Include(p => p.User)
                .ToListAsync(cancellationToken);

        var response = doctors.Select(n => new GetAllNursesQueryResponse
        {
            Id = n.Id,
            UserId = n.UserId,
            User = n.User != null ? new UserDto
            {
                UserId = n.User.Id,
                IdentityNumber = n.User.IdentityNumber,
                FirstName = n.User.FirstName,
                LastName = n.User.LastName,
                FullName = n.User.FullName,
                UserName = n.User.UserName,
                Email = n.User.Email,
                DateOfBirth = n.User.DateOfBirth,
                BloodType = n.User.BloodType,
                City = n.User.City,
                Town = n.User.Town,
                FullAddress = n.User.FullAddress
            } : null,
            Department = n.Department!.Name,
            Shift = n.Shift
        }).ToList();

        return response;
    }
}
