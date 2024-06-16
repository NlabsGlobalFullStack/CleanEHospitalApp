using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Users.Queries.Doctors.GetAllDoctors;
public sealed record GetAllDoctorsQuery : IRequest<Result<List<GetAllDoctorsQueryResponse>>>;
