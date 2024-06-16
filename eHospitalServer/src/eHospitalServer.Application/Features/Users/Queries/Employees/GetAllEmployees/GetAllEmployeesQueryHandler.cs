using eHospitalServer.Domain.DTOs;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Users.Queries.Employees.GetAllEmployees;

internal sealed class GetAllEmployeesQueryHandler(
    IEmployeeRepository employeeRepository
) : IRequestHandler<GetAllEmployeesQuery, Result<List<GetAllEmployeesQueryResponse>>>
{
    public async Task<Result<List<GetAllEmployeesQueryResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var doctors = await employeeRepository.GetAll()
                .Include(p => p.Department)
                .Include(p => p.User)
                .ToListAsync(cancellationToken);

        var response = doctors.Select(e => new GetAllEmployeesQueryResponse
        {
            Id = e.Id,
            UserId = e.UserId,
            User = e.User != null ? new UserDto
            {
                UserId = e.User.Id,
                IdentityNumber = e.User.IdentityNumber,
                FirstName = e.User.FirstName,
                LastName = e.User.LastName,
                FullName = e.User.FullName,
                UserName = e.User.UserName,
                Email = e.User.Email,
                DateOfBirth = e.User.DateOfBirth,
                BloodType = e.User.BloodType,
                City = e.User.City,
                Town = e.User.Town,
                FullAddress = e.User.FullAddress
            } : null,
            Department = e.Department!.Name,
            Position = e.Position
        }).ToList();

        return response;
    }
}
