using eHospitalServer.Domain.Repositories;
using eHospitalServer.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eHospitalServer.Application.Features.Home.GetAllDoctors;
public sealed record GetAllDoctorsQuery : IRequest<Result<List<GetAllDoctorsQueryResponse>>>;

internal sealed class GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsQuery, Result<List<GetAllDoctorsQueryResponse>>>
{
    public async Task<Result<List<GetAllDoctorsQueryResponse>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await doctorRepository.GetAll()
                .Include(p => p.Department)
                .Include(p => p.User)
                .Where(p => p.User!.IsDeleted == false)
                .ToListAsync(cancellationToken);

        var response = doctors.Select(d => new GetAllDoctorsQueryResponse
        {
            Id = d.Id,
            FullName = d.User!.FullName,
            Department = d.Department!.Name,
            Specialty = d.Specialty,
            AppointmentPrice = d.AppointmentPrice
        }).ToList();

        return response;
    }
}
