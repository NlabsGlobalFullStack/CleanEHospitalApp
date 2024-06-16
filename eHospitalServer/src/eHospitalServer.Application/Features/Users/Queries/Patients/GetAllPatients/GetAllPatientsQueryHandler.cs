using eHospitalServer.Domain.DTOs;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Users.Queries.Patients.GetAllPatients;

internal sealed class GetAllPatientsQueryHandler(
    IPatientRepository patientRepository
) : IRequestHandler<GetAllPatientsQuery, Result<List<GetAllPatientsQueryResponse>>>
{
    public async Task<Result<List<GetAllPatientsQueryResponse>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await patientRepository.GetAll()
                .Include(p => p.User)
                .ToListAsync(cancellationToken);

        var response = patients.Select(n => new GetAllPatientsQueryResponse
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
        }).ToList();

        return response;
    }
}
