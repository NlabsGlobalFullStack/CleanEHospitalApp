using eHospitalServer.Infrastructure.Results;
using MediatR;

namespace eHospitalServer.Application.Features.Home.GetAllDoctors;
public sealed record GetAllDoctorsQuery : IRequest<Result<List<GetAllDoctorsQueryResponse>>>;
