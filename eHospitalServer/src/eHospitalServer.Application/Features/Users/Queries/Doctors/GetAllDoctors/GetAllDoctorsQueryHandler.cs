using eHospitalServer.Domain.DTOs;
using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Users.Queries.Doctors.GetAllDoctors;

internal sealed class GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsQuery, Result<List<GetAllDoctorsQueryResponse>>>
{
    public async Task<Result<List<GetAllDoctorsQueryResponse>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await doctorRepository.GetAll()
                .Include(p => p.Department)
                .Include(p => p.User)
                .ToListAsync(cancellationToken);

        var response = doctors.Select(d => new GetAllDoctorsQueryResponse
        {
            Id = d.Id,
            UserId = d.UserId,
            User = d.User != null ? new UserDto
            {
                UserId = d.User.Id,
                IdentityNumber = d.User.IdentityNumber,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                FullName = d.User.FullName,
                UserName = d.User.UserName,
                Email = d.User.Email,
                DateOfBirth = d.User.DateOfBirth,
                BloodType = d.User.BloodType,
                City = d.User.City,
                Town = d.User.Town,
                FullAddress = d.User.FullAddress
            } : null,
            Department = d.Department!.Name,
            Specialty = d.Specialty,
            AppointmentPrice = d.AppointmentPrice
        }).ToList();

        return response;
    }
}
