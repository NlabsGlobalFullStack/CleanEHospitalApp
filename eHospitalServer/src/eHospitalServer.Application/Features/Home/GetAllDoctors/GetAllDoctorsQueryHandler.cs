using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Home.GetAllDoctors;

internal sealed class GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsQuery, Result<List<GetAllDoctorsQueryResponse>>>
{
    public async Task<Result<List<GetAllDoctorsQueryResponse>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await doctorRepository.GetAll()
                .Include(p => p.Department)
                .Include(p => p.User)
                .Where(p => p.User!.Doctor!.IsDeleted == false)
                .ToListAsync(cancellationToken);

        var response = doctors.Select(d => new GetAllDoctorsQueryResponse
        {
            FullName = d.User!.FullName,
            DepartmentName = d.Department!.Name,
            Specialty = d.Specialty,
            AppointmentPrice = d.AppointmentPrice,
            UserImage = d.User.Image!
        }).ToList();

        return response;
    }
}
